
using CoreBusiness;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Plugin.Datastore.SQLServer
{
    public class ApplicationDbContext:IdentityDbContext<User, Role, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //SeedData.Initialize(this);
        }

        public DbSet<AdministrativeDivision> AdministrativeDivisions { get; set; }
        public DbSet<AdministrativeDivisionType> AdministrativeDivisionTypes { get; set; }
        public DbSet<Bag> Bags { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Log> Logs { get; set; }
        //public DbSet<User> TempUsers { get; set; }
        //public DbSet<Role> TempRoles { get; set; }
        //public DbSet<TempUserRole> TempUserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            SeedData.SeedCountries(modelBuilder);
            //SeedData.SeedRoles(modelBuilder);

            // Allow only ONE cascade delete
            //modelBuilder.Entity<AdministrativeDivisionType>()
            //    .HasOne(t => t.Country)
            //    .WithMany()
            //    .HasForeignKey(t => t.CountryId)
            //    .OnDelete(DeleteBehavior.Cascade); // KEEP this one


            // Restrict cascade for the others
            //modelBuilder.Entity<AdministrativeDivision>()
            //    .HasOne(d => d.Country)
            //    .WithMany()
            //    .HasForeignKey(d => d.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<TempUserRole>()
            //.HasKey(r => new { r.TempUserId, r.TempRoleId});

            // AdministrativeDivisionType.Country - Disable cascade
            //modelBuilder.Entity<AdministrativeDivisionType>()
            //    .HasOne(a => a.Country)
            //    .WithMany(c => c.AdministrativeDivisionTypes)
            //    .HasForeignKey(a => a.CountryId)
            //    .OnDelete(DeleteBehavior.Restrict); // 👈 Prevent cascade here

            // AdministrativeDivision.Country - Leave as default (Cascade or Restrict)

            // Additional configurations can be added here if needed
        }
    }
}
