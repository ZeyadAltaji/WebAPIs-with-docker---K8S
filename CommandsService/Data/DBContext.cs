using CommandsService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandsService.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DbContext>option):base(option){}
        DbSet<Command>commands{get;set;}
        DbSet<PlatFroms>platfroms{get;set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
                modelBuilder
                .Entity<PlatFroms>()
                .HasMany(p=>p.Commands)
                .WithOne(p=>p.platFroms!)
                .HasForeignKey(p=>p.PlatFromsId);
                modelBuilder
                .Entity<Command>()
                .HasOne(p=>p.platFroms)
                .WithMany(p=>p.Commands)
                .HasForeignKey(p=>p.PlatFromsId);                
        }
    }

}
