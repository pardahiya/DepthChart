using System.Collections.Generic;

namespace CodeTest.DepthChart.Domain
{
	public class SportsSettings
	{
		public const string SportsConfigSection = "SportsConfig";
		public Dictionary<string, List<string>> SportPositionsMappings { get; set; }
	}
}