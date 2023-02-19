// See https://aka.ms/new-console-template for more information
using CodeTest.DepthChart.Domain;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using CodeTest.DepthChart.Domain.Services;
using CodeTest.DepthChart.Domain.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        using IHost host = Host.CreateDefaultBuilder(args)
            .ConfigureServices((builder, services) =>
            {
                services.Configure<SportsSettings>(builder.Configuration.GetSection(
                                                SportsSettings.SportsConfigSection));
                services.AddSingleton<ITeamBuilder, TeamBuilder>();
            })
            .ConfigureAppConfiguration(builder => builder.AddJsonFile("Sports.json"))
            .Build();

        using IServiceScope serviceScope = host.Services.CreateScope();
        IServiceProvider provider = serviceScope.ServiceProvider;
        var teamBuilder = provider.GetRequiredService<ITeamBuilder>();

        var teamNFL1 = teamBuilder.BuiildSportsTeam("NFL");
        var teamMLB1 = teamBuilder.BuiildSportsTeam("MLB");

        var bob = new Player { Id = 1, Name = "Bob" };
        var alice = new Player { Id = 2, Name = "Alice" };
        var charlie = new Player { Id = 3, Name = "Charlie" };

        teamNFL1.AddPlayerToDepthChart(bob, "WR", 0);
        teamNFL1.AddPlayerToDepthChart(alice, "WR", 0);
        teamNFL1.AddPlayerToDepthChart(charlie, "WR", 2);
        teamNFL1.AddPlayerToDepthChart(bob, "KR");
        var depthChart = teamNFL1.GetFullDepthChart();
        Console.WriteLine(string.Join($",{Environment.NewLine}", depthChart));

        Console.ReadLine();
    }
}