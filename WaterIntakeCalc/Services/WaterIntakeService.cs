using System;
using System.Collections.Generic;
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
        private WaterIntakeDataAccess _waterIntakeDataAccess;
        public WaterIntakeService()
        {
            _waterIntakeDataAccess = new WaterIntakeDataAccess(new ApplicationDbContext());
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
                _waterIntakeDataAccess.AddWaterIntake(model);
                return ResponseContent<string>.SuccessResult();
            }
            catch (Exception e)
            {
                return ResponseContent<string>.Failure(e.Message);
            }
        }
    }
}