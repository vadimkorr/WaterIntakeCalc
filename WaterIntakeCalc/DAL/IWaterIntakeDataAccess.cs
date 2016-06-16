using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterIntakeCalc.Models;

namespace WaterIntakeCalc.DAL
{
    public interface IWaterIntakeDataAccess
    {
        WaterIntakeModel GetItemByUserIdAndDate(string id, DateTime date);
        void Add(WaterIntakeModel model);
        void Update(WaterIntakeModel model);
        List<WaterIntakeModel> GetItemsOfWeek(string UserId, DateTime from, DateTime to);
        List<WaterIntakeModel> GetItemsOfMonth(WaterIntakeModel model);
    }
}
