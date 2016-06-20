using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WaterIntakeCalc.Models;

namespace WaterIntakeCalc.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            bool dropAndCreateDb = true;
            if (dropAndCreateDb)
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            }
            else
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            }
        }

        public DbSet<WaterIntakeModel> WaterIntakes { get; set; }
        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    //one-to-many 
        //    modelBuilder.Entity<WaterIntakeModel>()
        //                .HasRequired<ApplicationUser>(s => s.UserId) // WI entity requires AppUser 
        //                .WithMany(s => s.WaterIntakes); // AppUser entity includes many WI entities

        //}

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
        {
            public Configuration()
            {
                AutomaticMigrationsEnabled = false;
                AutomaticMigrationDataLossAllowed = true;
            }
        }
    }
}