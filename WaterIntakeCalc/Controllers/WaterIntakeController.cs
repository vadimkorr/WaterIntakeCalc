using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Http.Headers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WaterIntakeCalc.DAL;
using WaterIntakeCalc.Models;
using WaterIntakeCalc.Results;
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
        [HttpGet]
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

        [Route("GetChartOfWeek")]
        [HttpGet]
        public HttpResponseMessage GetChartOfWeek()
        {
            WaterIntakeModel model = new WaterIntakeModel()
            {
                Date = DateTime.Now,
                UserId = HttpContext.Current.User.Identity.GetUserId()
            };
            var res = _waterIntakeService.GetChartOfWeek(model);

            if (res == null)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    ResponseContent<string>.Failure("No data available for requested week"));
            }
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            byte[] imgData = res;


            MemoryStream ms = new MemoryStream(imgData);
            response.Content = new StreamContent(ms);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/png");

           // Image i = Image.FromStream(ms);
           // i.Save("D:/chart2.png", ImageFormat.Png);

            return response;
        }
    }
}