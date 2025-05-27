using LumenSolar.WebAPI.Models.Doadores;
using LumenSolar.WebAPI.Models.Familias;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LumenSolar.WebAPI.Data
{
    public class Context : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Familia> Familia { get; set; }
        public DbSet<Doador> Doador { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Familia>()
                        .HasOne(f => f.User)
                        .WithOne()
                        .HasForeignKey<Familia>(f => f.UserId);

            modelBuilder.Entity<Doador>()
                        .HasOne(f => f.User)
                        .WithOne()
                        .HasForeignKey<Doador>(f => f.UserId);
        }               
    }
}
