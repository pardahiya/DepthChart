using System;
using CodeTest.DepthChart.Domain.Models;
using Microsoft.Extensions.Options;

namespace CodeTest.DepthChart.Domain.Services
{
    public class TeamBuilder : ITeamBuilder
    {
        private readonly SportsSettings _sportsSettings;

        public TeamBuilder(IOptions<SportsSettings> sportsSettingsOptions)
        {
            if (sportsSettingsOptions?.Value.SportPositionsMappings == null)
            {
                throw new Exception("Invalid sports config");
            }
            _sportsSettings = sportsSettingsOptions.Value;
        }
        public Team BuiildSportsTeam(string sportName)
        {
            if (!_sportsSettings.SportPositionsMappings.ContainsKey(sportName)) throw new Exception("No such sport exist.");

            var sportSettings = _sportsSettings.SportPositionsMappings[sportName];

            return new Team(sportName, sportSettings);
        }
    }
}