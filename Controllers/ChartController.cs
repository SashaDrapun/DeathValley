using DeathValley.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Storage;
using DeathValley.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeathValley.Controllers
{
    [Route("api/[controller]")]
    public class ChartController : ControllerBase, IDisposable
    {
        public ChartController(ApplicationContext dbContext)
        {
            pointRepository = new PointRepository(dbContext);
            userDataRepository = new UserDataRepository(dbContext);
        }

        [HttpPost]
        public ActionResult<ChartData> Post([FromBody]UserData userData)
        {
            if(userData.RangeFrom > userData.RangeTo)
            {
                ModelState.AddModelError("RangeFrom", "Значение 'От' не должно превышать значение 'до'");
            }
            if (ModelState.IsValid)
            {
                CalculateChart calculateChart = new CalculateChart(userData);
                ChartData chartData = calculateChart.GetChartData();
                userDataRepository.Create(userData);
                userDataRepository.Save();
                for (int i = 0; i < chartData.Points.Length; i++)
                {
                    pointRepository.Create(new Point(userData.UserDataId, chartData.Points[i].X, chartData.Points[i].Y));
                }
                pointRepository.Save();
                return Ok(chartData);
            }
            else
            {
                return BadRequest(ModelState);
            } 
        }

        #region Disposable

        private bool disposed;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    pointRepository.Dispose();
                    userDataRepository.Dispose();
                }

                disposed = true;
            }
        }

        ~ChartController()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion Disposable

        PointRepository pointRepository;
        UserDataRepository userDataRepository;
    }
}
