using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Garago.Data;
using Garago.Data.Seeds;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Garago.Web
{
    public class Program
    {

        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
           .AddEnvironmentVariables()
           .Build();
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args);
            try {

                
                using (var scope = host.Services.GetService<IServiceScopeFactory>().CreateScope())
                {
                    using (var dbContext = scope.ServiceProvider.GetRequiredService<GaragoContext>())
                    {
                        dbContext.Database.Migrate();
                        EnsureGaragoUsersData.Seed(dbContext);
                        EnsureGarageSalesData.Seed(dbContext);
                    }
                
                }
               
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<GaragoContext>();

                    EnsureGaragoUsersData.Seed(context);    
                    EnsureGarageSalesData.Seed(context);
                    //EnsureProductsData.Seed(context);

                }

            }
            catch (Exception databaseEx) {

                Console.WriteLine(databaseEx);
            }
    
            try
            {
               host.Run();
            } catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static IWebHost CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
