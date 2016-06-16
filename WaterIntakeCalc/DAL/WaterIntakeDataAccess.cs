using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WaterIntakeCalc.Const;
using WaterIntakeCalc.Models;

namespace WaterIntakeCalc.DAL
{
    public class WaterIntakeDataAccess : IWaterIntakeDataAccess
    {
        private ApplicationDbContext _dbContext;

        public WaterIntakeDataAccess(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public WaterIntakeModel GetItemByUserIdAndDate(string id, DateTime date)
        {
            WaterIntakeModel item = _dbContext.WaterIntakes.Select(x => x).Where(x => x.UserId == id && x.Date == date).FirstOrDefault();
            return item;
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

        public List<WaterIntakeModel> GetItemsOfWeek(string userId, DateTime from, DateTime to)
        {
            return _dbContext.WaterIntakes.Where(x => x.Date >= from && x.Date <= to && x.UserId == userId).Select(x => x).ToList();
        }

        public List<WaterIntakeModel> GetItemsOfMonth(WaterIntakeModel model)
        {
            return _dbContext.WaterIntakes.Where(x => x.Date.Year == model.Date.Year && x.Date.Month == model.Date.Month && x.UserId == model.UserId).Select(x => x).ToList();
        }
    }
}