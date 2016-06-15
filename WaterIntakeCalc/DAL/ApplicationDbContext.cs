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

        public DbSet<WaterIntakeModel> WaterIntakes;
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