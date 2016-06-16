using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WaterIntakeCalc.DAL;
using WaterIntakeCalc.Models;
using WaterIntakeCalc.Services;

namespace WaterIntakeCalc.Controllers
{
    [Authorize]
    [RoutePrefix("api/waterintake")]
    public class WaterIntakeController : ApiController
    {
        WaterIntakeService _waterIntakeService;
        public WaterIntakeController()
        {
            _waterIntakeService = new WaterIntakeService(new WaterIntakeDataAccess(new ApplicationDbContext()));
        }

        [Route("AddWaterIntake/{amount}")]
        public HttpResponseMessage AddWaterIntake(int amount)
        {
            WaterIntakeModel model = new WaterIntakeModel()
            {
                WaterAmount = amount,
                Date = DateTime.Now.Date,
                UserId = HttpContext.Current.User.Identity.GetUserId()
            };
            var result = _waterIntakeService.AddWaterIntake(model);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("AddWaterIntake/GetChartOfWeek")]
        public HttpResponseMessage GetChartOfWeek()
        {
            WaterIntakeModel model = new WaterIntakeModel()
            {
                Date = DateTime.Now,
                UserId = HttpContext.Current.User.Identity.GetUserId()
            };
            _waterIntakeService.GetChartOfWeek(model);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}