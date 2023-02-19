using CodeTest.DepthChart.Domain.Models;

namespace CodeTest.DepthChart.Domain.Services
{
    public interface ITeamBuilder
    {
        Team BuiildSportsTeam(string sportName);
    }
}