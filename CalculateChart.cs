using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace DeathValley
{
    public class CalculateChart
    {
        private Models.UserData userData;

        public CalculateChart(Models.UserData userData)
        {
            this.userData = userData;
        }

        public ChartData GetChartData()
        {
            List<string> labels = new List<string>();
            List<Point> points = new List<Point>();

            for (int x = userData.RangeFrom; x <= userData.RangeTo; x+=userData.Step)
            {
                labels.Add(x.ToString());
                int y = x * x * userData.A + userData.B * x + userData.C;
                points.Add(new Point(x,y));
            }
            return new ChartData(labels.ToArray(),points.ToArray());
        }
    }
}
