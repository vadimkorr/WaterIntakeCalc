using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WaterIntakeCalc.Models;

namespace WaterIntakeCalc.DAL
{
    public class WaterIntakeDataAccess
    {
        private ApplicationDbContext _dbContext;

        public WaterIntakeDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddWaterIntake(WaterIntakeModel model)
        {
            WaterIntakeModel item = _dbContext.WaterIntakes.Select(x => x).Where(x => x.UserId == model.UserId && x.Date == model.Date).FirstOrDefault();
            if (item == null)
            {
                Add(item);
            }
            else
            {
                item.WaterAmount += model.WaterAmount;
                Update(item);
            }
        }

        public void Add(WaterIntakeModel model)
        {
            _dbContext.WaterIntakes.Add(model);
            _dbContext.SaveChanges();
        }

        public void Update(WaterIntakeModel model)
        {
            _dbContext.WaterIntakes.Attach(model);
            _dbContext.Entry(model).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}