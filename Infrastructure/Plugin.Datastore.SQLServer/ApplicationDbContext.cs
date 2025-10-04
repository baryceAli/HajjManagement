
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
        public DbSet<CountryStructure> CountryStructures { get; set; }
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
         //SeedData.SeedRolesAsync(modelBuilder).GetAwaiter().GetResult();
            //SeedData.SeedRoles(modelBuilder);


        }
        
    }
}
