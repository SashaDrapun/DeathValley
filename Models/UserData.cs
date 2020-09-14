using System;
using System.Collections.Generic;

#nullable disable

namespace DeathValley.Models
{
    public partial class UserData
    {
        public UserData()
        {
            Points = new HashSet<Point>();
        }

        public int UserDataId { get; set; }
        public int RangeFrom { get; set; }
        public int RangeTo { get; set; }
        public int Step { get; set; }
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public virtual ICollection<Point> Points { get; set; }
    }
}
