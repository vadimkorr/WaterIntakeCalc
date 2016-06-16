using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterIntakeCalc.Const;
using WaterIntakeCalc.DAL;
using WaterIntakeCalc.Models;

namespace WaterIntakeCalc.Tests.Services
{
    class DummyWaterIntakeDataAccess : IWaterIntakeDataAccess
    {
        List<WaterIntakeModel> _waterIntakeModels;
        public DummyWaterIntakeDataAccess()
        {
            _waterIntakeModels = new List<WaterIntakeModel>();
            Random rndAmount = new Random();
            DateTime initDate = new DateTime(DateTime.Now.Year, 1, 1);
            for (int i = 0; i < 35; i++)
            {
                initDate = initDate.AddDays(1);
                WaterIntakeModel model = new WaterIntakeModel()
                {
                    WaterIntakeId = i,
                    WaterAmount = rndAmount.Next(1000, 3000),
                    Date = initDate,
                    UserId = string.Format("someId{0}", i)
                };
                _waterIntakeModels.Add(model);
            }
        }

        public void Add(WaterIntakeModel model)
        {
            throw new NotImplementedException();
        }

        public WaterIntakeModel GetItemByUserIdAndDate(string id, DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<WaterIntakeModel> GetItemsOfMonth(WaterIntakeModel model)
        {
            return _waterIntakeModels.Where(x => x.Date.Year == model.Date.Year && x.Date.Month == model.Date.Month).Select(x => x).ToList();
        }

        public List<WaterIntakeModel> GetItemsOfWeek(string UserId, DateTime from, DateTime to)
        {
            return _waterIntakeModels.Where(x => x.Date >= from && x.Date <= to).Select(x => x).ToList();
        }

        public void Update(WaterIntakeModel model)
        {
            throw new NotImplementedException();
        }
    }
}
