using DeathValley.Models;
using System;
using System.Collections.Generic;
using CommonPoint = System.Drawing.Point;
using System.Linq;
using System.Threading.Tasks;

namespace DeathValley
{
    public class CalculateChart
    {
        private UserData userData;

        public CalculateChart(UserData userData)
        {
            this.userData = userData;
        }

        public ChartData GetChartData()
        {
            List<string> labels = new List<string>();
            List<CommonPoint> points = new List<CommonPoint>();

            for (int x = userData.RangeFrom; x <= userData.RangeTo; x+=userData.Step)
            {
                labels.Add(x.ToString());
                int y = x * x * userData.A + userData.B * x + userData.C;
                points.Add(new CommonPoint(x,y));
            }
            return new ChartData(labels.ToArray(),points.ToArray());
        }
    }
}
