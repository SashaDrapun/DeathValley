using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Укажите range from")]
        public int RangeFrom { get; set; }

        [Required(ErrorMessage = "Укажите range to")]
        public int RangeTo { get; set; }

        [Required(ErrorMessage = "Укажите step")]
        [Range(1, 10, ErrorMessage = "Step должен быть в промежутке от 1 до 10")]
        public int Step { get; set; }

        [Required(ErrorMessage = "Укажите A")]
        public int A { get; set; }

        [Required(ErrorMessage = "Укажите B")]
        public int B { get; set; }
        [Required(ErrorMessage = "Укажите C")]
        public int C { get; set; }

        public virtual ICollection<Point> Points { get; set; }
    }
}
