using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MinisteringInterviews.Data;
using MinisteringInterviews.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinisteringInterviews.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DataGenerator.Seed(services);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }

    public class DataGenerator
    {
        public static void Seed(IServiceProvider services)
        {
            var context = services.GetRequiredService<AppDbContext>();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Members.AddRange(
                new Member { LastName = "Rand", FirstName = "Ben" },
                new Member { LastName = "Wadsworth", FirstName = "Brad" }
            );

            context.SaveChanges();
        }
    }

}
