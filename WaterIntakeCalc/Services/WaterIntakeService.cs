using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WaterIntakeCalc.Const;
using WaterIntakeCalc.DAL;
using WaterIntakeCalc.Models;
using WaterIntakeCalc.Results;

namespace WaterIntakeCalc.Services
{
    public class WaterIntakeService
    {
        private IWaterIntakeDataAccess _waterIntakeDataAccess;
        public WaterIntakeService(IWaterIntakeDataAccess waterIntakeDataAccess)
        {
            _waterIntakeDataAccess = waterIntakeDataAccess;
        }

        public ResponseContent<string> AddWaterIntake(WaterIntakeModel model)
        {
            if (model.WaterAmount < 0)
            {
                return ResponseContent<string>.Failure(ResponseMessages.NEGATIVE_AMOUNT);
            }
            if (model.WaterAmount == 0)
            {
                return ResponseContent<string>.Failure(ResponseMessages.ZERO_AMOUNT);
            }

            try
            {
                var item = _waterIntakeDataAccess.GetItemByUserIdAndDate(model.UserId, model.Date);
                if (item == null)
                {
                    _waterIntakeDataAccess.Add(item);
                }
                else
                {
                    item.WaterAmount += model.WaterAmount;
                    _waterIntakeDataAccess.Update(item);
                }
                return ResponseContent<string>.SuccessResult();
            }
            catch (Exception e)
            {
                return ResponseContent<string>.Failure(e.Message);
            }
        }

        public byte[] GetChartOfWeek(WaterIntakeModel model)
        {
            ChartService _chartService = new ChartService();

            int dayOfWeek = (int)model.Date.DayOfWeek;
            DateTime from = model.Date.AddDays(-dayOfWeek);
            DateTime to = model.Date.AddDays(ChartConst.DAYS_IN_WEEK - 1  - dayOfWeek);

            List<WaterIntakeModel> models = _waterIntakeDataAccess.GetItemsOfWeek(model.UserId, from, to);
            List<DateTime> dates = models.Select(x => x.Date).ToList();
            List<int> amounts = models.Select(x => x.WaterAmount).ToList();
            if (amounts.Count() == 0)
            {
                return null;
            }
            return _chartService.CreateChartOfWeek(dates, amounts);
        }

    }
}