using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovie
{
  public class Program
  {
    public static ILogger Logger;
    public static IServiceProvider Services;

    public static void Main(string[] args)
    {
      
      var host = BuildWebHost(args);
      SetupLogging(host);
      BuildSeedData(host);
      host.Run();
    }

    private static void SetupLogging(IWebHost host){
      var scope = host.Services.CreateScope();
      Services = scope.ServiceProvider;
      Logger = Services.GetRequiredService<ILogger<Program>>();
      Logger.LogInformation("Logging enabled");
    }

    private static void BuildSeedData(IWebHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        try
        {
          SeedData.Initialize(Services);
        }
        catch (Exception ex)
        {
          Logger.LogError(ex, $"An error occurred seeding the DB: {ex.InnerException.Message}");
        }
      }
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
