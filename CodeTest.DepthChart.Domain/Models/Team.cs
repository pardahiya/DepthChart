using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace CodeTest.DepthChart.Domain.Models
{
	public class Team
	{
        private readonly Dictionary<string, DepthChart> _positions = new Dictionary<string, DepthChart>();

        public Guid Id { get; }
        public string Sport { get; }

        public Team(string sport, IEnumerable<string> positionNames)
        {
            Id = Guid.NewGuid();
            Sport = sport;
            positionNames.ToList().ForEach(positionName => _positions.Add(positionName, new DepthChart()));
        }

        public void AddPosition(string positionName)
        {
            if (string.IsNullOrWhiteSpace(positionName) || _positions.ContainsKey(positionName)) return;

            _positions.Add(positionName, new DepthChart());
        }

        public void AddPlayerToDepthChart(Player player, string position, int? depthOrder = null)
        {
            var positionDepthChart = GetDepthChart(position);
            positionDepthChart.AddPlayerToDepthChart(player.Id, depthOrder);
        }

        public void RemovePlayerFromDepthChart(Player player, string position)
        {
            var positionDepthChart = GetDepthChart(position);
            positionDepthChart?.RemovePlayerFromDepthChart(player.Id);
        }

        public List<int> GetPlayersUnderPlayerInDepthChart(Player player, string position)
        {
            var positionDepthChart = GetDepthChart(position);
            return positionDepthChart?.GetPlayersUnderPlayerInDepthChart(player.Id) ?? new List<int>();
        }

        public List<string> GetFullDepthChart()
        {
            return _positions.Select(FormatPositionDepthChart()).ToList();

            static Func<KeyValuePair<string, DepthChart>, string> FormatPositionDepthChart()
            {
                return p => $"{p.Key}: [{string.Join(", ", p.Value.GetDepthChart())}]";
            }
        }

        public IEnumerable<int> GetDepthChartForPosition(string position)
        {
            return GetDepthChart(position).GetDepthChart();
        }

        private DepthChart GetDepthChart(string position)
        {
            if (!_positions.ContainsKey(position)) throw new Exception($"Not a valid position for {Sport}");

            return _positions[position];
        }
    }
}