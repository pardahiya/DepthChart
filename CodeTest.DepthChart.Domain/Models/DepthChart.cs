using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;

namespace CodeTest.DepthChart.Domain.Models
{
	internal class DepthChart
	{
        // this represents player rankings for a position
        private readonly LinkedList<int> _depthChart = new LinkedList<int>();

        public void AddPlayerToDepthChart(int playerId, int? positionDepth = null)
        {
            //TODO: exceptions for validations?
            if (positionDepth < 0) return;

            if (_depthChart.Any(id => id == playerId)) return;

            if (positionDepth == null || positionDepth >= _depthChart.Count)
            {
                _depthChart.AddLast(playerId);
                return;
            }

            var currentNode = _depthChart.First;
            var currentIndex = 0;

            if (currentNode == null || positionDepth == 0)
            {
                _depthChart.AddFirst(playerId);
                return;
            }

            while (currentNode != null && currentIndex <= positionDepth)
            {
                if (currentIndex == positionDepth)
                {
                    _depthChart.AddBefore(currentNode, playerId);
                }
                currentIndex++;
                currentNode = currentNode.Next;
            }
        }

        public void RemovePlayerFromDepthChart(int playerId)
        {
            var playerNodeToRemove = _depthChart.Find(playerId);
            if (playerNodeToRemove == null) return;

            _depthChart.Remove(playerNodeToRemove);
        }

        public List<int> GetPlayersUnderPlayerInDepthChart(int playerId)
        {
            var playerList = new List<int>();
            var playerNode = _depthChart.Find(playerId);
            if (playerNode == null) return playerList;

            playerNode = playerNode.Next;
            while (playerNode != null)
            {
                playerList.Add(playerNode.Value);
                playerNode = playerNode.Next;
            }
            return playerList;
        }

        public IEnumerable<int> GetDepthChart()
        {
            return _depthChart.ToList();
        }
    }
}

