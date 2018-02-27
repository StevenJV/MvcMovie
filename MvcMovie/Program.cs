using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MvcMovie.Models;

namespace MvcMovie
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var host = BuildWebHost(args);
      BuildSeedData(host);
      host.Run();
    }

    private static void BuildSeedData(IWebHost host){
      using (var scope = host.Services.CreateScope()) {
        var services = scope.ServiceProvider;
        try {
          SeedData.Initialize(services);
        }
        catch (Exception ex) {
          var logger = services.GetRequiredService<ILogger<Program>>();
          logger.LogError(ex, $"An error occurred seeding the DB: {ex.InnerException.Message}");
        }
      }
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
