using CodeTest.DepthChart.Domain;
using CodeTest.DepthChart.Domain.Models;
using CodeTest.DepthChart.Domain.Services;
using Microsoft.Extensions.Options;

namespace CodeTest.DepthChart.Tests;

public class TeamTests
{
    private readonly ITeamBuilder _teamBuilder;
    public TeamTests()
    {
        var sportSettings = new SportsSettings()
        {
            SportPositionsMappings = new Dictionary<string, List<string>>
            {
                { "SPORT1", new List<string> { "P1", "P2" } },
                { "SPORT2", new List<string> { "P1", "P2" } }
            }
        };
        _teamBuilder = new TeamBuilder(Options.Create(sportSettings));
    }


    [Fact]
    public void PlayersAreAddedToDepthDepth()
    {
        var player1 = new Player { Id = 1, Name = "Player1" };
        var player2 = new Player { Id = 2, Name = "Player2" };
        var player3 = new Player { Id = 3, Name = "Player3" };
        var player4 = new Player { Id = 4, Name = "Player4" };
        var player5 = new Player { Id = 5, Name = "Player5" };
        var player6 = new Player { Id = 6, Name = "Player6" };
        var player7 = new Player { Id = 7, Name = "Player7" };
        var player8 = new Player { Id = 8, Name = "Player8" };

        //build a SPORT1 TEAM
        var team = _teamBuilder.BuiildSportsTeam("SPORT1");

        team.AddPlayerToDepthChart(player1, "P1", 0);
        team.AddPlayerToDepthChart(player2, "P1", 1);
        team.AddPlayerToDepthChart(player3, "P1", 2);
        team.AddPlayerToDepthChart(player4, "P1", 5);

        var depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 1, "Player1 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 2, "Player2 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 3, "Player3 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 4, "Player4 should be fourth in P1 depth chart");

        team.AddPlayerToDepthChart(player5, "P1", 0);
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 5, "Player5 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 1, "Player1 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 2, "Player2 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 3, "Player3 should be fourth in P1 depth chart");
        Assert.True(depthChartP1[4] == 4, "Player4 should be fifth in P1 depth chart");

        team.AddPlayerToDepthChart(player6, "P1", 2);
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 5, "Player5 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 1, "Player1 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 6, "Player6 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 2, "Player2 should be fourth in P1 depth chart");
        Assert.True(depthChartP1[4] == 3, "Player3 should be fifth in P1 depth chart");
        Assert.True(depthChartP1[5] == 4, "Player4 should be fifth in P1 depth chart");

        team.AddPlayerToDepthChart(player7, "P1", 5);
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 5, "Player5 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 1, "Player1 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 6, "Player6 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 2, "Player2 should be fourth in P1 depth chart");
        Assert.True(depthChartP1[4] == 3, "Player3 should be fifth in P1 depth chart");
        Assert.True(depthChartP1[5] == 7, "Player7 should be sixth in P1 depth chart");
        Assert.True(depthChartP1[6] == 4, "Player4 should be seventh in P1 depth chart");

        team.AddPlayerToDepthChart(player8, "P1", 7);
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 5, "Player5 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 1, "Player1 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 6, "Player6 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 2, "Player2 should be fourth in P1 depth chart");
        Assert.True(depthChartP1[4] == 3, "Player3 should be fifth in P1 depth chart");
        Assert.True(depthChartP1[5] == 7, "Player7 should be sixth in P1 depth chart");
        Assert.True(depthChartP1[6] == 4, "Player4 should be seventh in P1 depth chart");
        Assert.True(depthChartP1[7] == 8, "Player8 should be eigth in P1 depth chart");
    }

    [Fact]
    public void PlayersAreRemovedFromDepthChart()
    {
        var player1 = new Player { Id = 1, Name = "Player1" };
        var player2 = new Player { Id = 2, Name = "Player2" };
        var player3 = new Player { Id = 3, Name = "Player3" };
        var player4 = new Player { Id = 4, Name = "Player4" };
        var player5 = new Player { Id = 5, Name = "Player5" };
        var player6 = new Player { Id = 6, Name = "Player6" };

        //build a SPORT1 TEAM
        var team = _teamBuilder.BuiildSportsTeam("SPORT1");

        team.AddPlayerToDepthChart(player1, "P1", 0);
        team.AddPlayerToDepthChart(player2, "P1", 1);
        team.AddPlayerToDepthChart(player3, "P1", 2);
        team.AddPlayerToDepthChart(player4, "P1", 3);
        team.AddPlayerToDepthChart(player5, "P1", 4);
        team.AddPlayerToDepthChart(player6, "P1", 5);

        var depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 1, "Player1 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 2, "Player2 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 3, "Player3 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 4, "Player4 should be fourth in P1 depth chart");
        Assert.True(depthChartP1[4] == 5, "Player5 should be fifth in P1 depth chart");
        Assert.True(depthChartP1[5] == 6, "Player6 should be sixth in P1 depth chart");

        team.RemovePlayerFromDepthChart(player3, "P1");
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 1, "Player1 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 2, "Player2 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 4, "Player4 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 5, "Player5 should be fourth in P1 depth chart");
        Assert.True(depthChartP1[4] == 6, "Player6 should be fifth in P1 depth chart");
        Assert.True(depthChartP1.Length == 5, "There should be 5 players P1 depth chart");

        team.RemovePlayerFromDepthChart(player6, "P1");
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 1, "Player1 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 2, "Player2 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 4, "Player4 should be third in P1 depth chart");
        Assert.True(depthChartP1[3] == 5, "Player5 should be fourth in P1 depth chart");
        Assert.True(depthChartP1.Length == 4, "There should be 4 players P1 depth chart");

        team.RemovePlayerFromDepthChart(player1, "P1");
        depthChartP1 = team.GetDepthChartForPosition("P1").ToArray();

        Assert.True(depthChartP1[0] == 2, "Player2 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 4, "Player4 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 5, "Player5 should be third in P1 depth chart");
        Assert.True(depthChartP1.Length == 3, "There should be 3 players P1 depth chart");
    }

    [Fact]
    public void GetDepthChartAfterPlayer()
    {
        var player1 = new Player { Id = 1, Name = "Player1" };
        var player2 = new Player { Id = 2, Name = "Player2" };
        var player3 = new Player { Id = 3, Name = "Player3" };
        var player4 = new Player { Id = 4, Name = "Player4" };
        var player5 = new Player { Id = 5, Name = "Player5" };
        var player6 = new Player { Id = 6, Name = "Player6" };

        //build a SPORT1 TEAM
        var team = _teamBuilder.BuiildSportsTeam("SPORT1");

        team.AddPlayerToDepthChart(player1, "P1", 0);
        team.AddPlayerToDepthChart(player2, "P1", 1);
        team.AddPlayerToDepthChart(player3, "P1", 2);
        team.AddPlayerToDepthChart(player4, "P1", 3);
        team.AddPlayerToDepthChart(player5, "P1", 4);
        team.AddPlayerToDepthChart(player6, "P1", 5);

        var depthChartP1 = team.GetPlayersUnderPlayerInDepthChart(player3, "P1").ToArray();
        Assert.True(depthChartP1[0] == 4, "Player4 should be first in P1 depth chart");
        Assert.True(depthChartP1[1] == 5, "Player5 should be second in P1 depth chart");
        Assert.True(depthChartP1[2] == 6, "Player6 should be third in P1 depth chart");
    }
}
