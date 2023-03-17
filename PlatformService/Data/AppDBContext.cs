using Microsoft.EntityFrameworkCore;
using PlatformService.Model;

namespace PlatformService.Data
{
    public class AppDBContext:DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> option):base(option)
        {
            
        }
        public DbSet<Platform> Platforms{get;set;}

    }
}