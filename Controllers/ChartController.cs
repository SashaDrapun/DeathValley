using DeathValley.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Text.Json;

namespace DeathValley.Controllers
{
    [Route("api/[controller]")]
    public class ChartController : ControllerBase
    {
        [HttpPost]
        public ActionResult<ChartData> Post([FromBody]UserData userData)
        {
            CalculateChart calculateChart = new CalculateChart(userData);
            ChartData chartData = calculateChart.GetChartData();
            return Ok(chartData);
        }
    }
}
