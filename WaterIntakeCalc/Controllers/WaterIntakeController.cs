using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
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
            _waterIntakeService = new WaterIntakeService();
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
    }
}