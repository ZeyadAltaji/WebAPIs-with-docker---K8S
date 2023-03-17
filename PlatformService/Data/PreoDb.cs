using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Model;

namespace PlatformService.Data
{
    public static class PreoDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
                using
                (
                    var serviceScope= app.ApplicationServices.CreateScope())
                    {
                            SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>());
                    }
               
        }
        private static void SeedData(AppDBContext DC)
        {
            if(!DC.Platforms.Any())
            {
                Console.WriteLine("==> Seeding Data...");
                DC.Platforms.AddRange
                (
                    new Platform()
                    {
                        Name="Dot Net",
                        Publisher="Microsoft",
                        Cost="Free"
                    },new Platform()
                    {
                        Name="SQL Server Express",
                        Publisher="Microsoft",
                        Cost="Free"
                    },
                    new Platform()
                    {
                        Name="Kubernetes",
                        Publisher="Cloud Native Computing Foundation",
                        Cost="Free"
                    }
                );
            }
            else
            {
                Console.WriteLine("==> We Already Have Data");
            }

        }

    }
}