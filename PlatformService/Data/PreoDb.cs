using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Model;

namespace PlatformService.Data
{
    public static class PreoDB
    {
        public static void PrepPopulation(IApplicationBuilder app,bool isProd)
        {
                using
                (
                    var serviceScope= app.ApplicationServices.CreateScope())
                    {
                            SeedData(serviceScope.ServiceProvider.GetService<AppDBContext>(),isProd);
                    }
               
        }
        private static void SeedData(AppDBContext DC,bool isProd)
        {
            if(isProd){
                 Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    DC.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"--> Could not run migrations: {ex.Message}");
                }
            }
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
                DC.SaveChanges();
            }
            else
            {
                Console.WriteLine("==> We Already Have Data");
            }

        }

    }
}