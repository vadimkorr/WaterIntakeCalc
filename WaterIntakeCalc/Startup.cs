using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using WaterIntakeCalc.DAL;

[assembly: OwinStartup(typeof(WaterIntakeCalc.Startup))]

namespace WaterIntakeCalc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            applicationDbContext.Database.Initialize(true);
        }
    }
}
