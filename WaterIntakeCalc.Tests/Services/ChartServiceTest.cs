using System.Drawing.Imaging;
using System.IO;
using System.Net.Mime;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterIntakeCalc.DAL;
using WaterIntakeCalc.Models;
using WaterIntakeCalc.Services;
using System.Drawing;

namespace WaterIntakeCalc.Tests.Services
{
    [TestFixture]
    class ChartServiceTest
    {
        private ChartService _chartService;
        private IWaterIntakeDataAccess _waterIntakeDataAccess;
        private WaterIntakeService _waterIntakeService;
        [SetUp]
        public void Setup()
        {
            _chartService = new ChartService();
            _waterIntakeDataAccess = new DummyWaterIntakeDataAccess();
            _waterIntakeService = new WaterIntakeService(_waterIntakeDataAccess);
        }

        [Test]
        public void CreateChart_SavesChartByWeek()
        {
            WaterIntakeModel model = new WaterIntakeModel()
            {
                Date = new DateTime(DateTime.Now.Year, 1, 10)
            };
            _waterIntakeService.GetChartOfWeek(model);

            byte[] image = _waterIntakeService.GetChartOfWeek(model);
            MemoryStream ms = new MemoryStream(image);
            Image i = Image.FromStream(ms);
            i.Save("D:/chart1.png", ImageFormat.Png);
        }
    }
}
