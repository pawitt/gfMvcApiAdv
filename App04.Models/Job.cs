using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Linq;

namespace App04.Models
{
    public class Job
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
        public string DriverName { get; set; }

        [StringLength(250)]
        public string FromLocation { get; set; }

        [StringLength(250)]
        public string ToLocation { get; set; }


        // Navigation properties
        [Required]
        public virtual Truck Truck { get; set; }

        public virtual ICollection<FillUp> FillUps { get; set; }
          = new HashSet<FillUp>();

        public FillUp AddFillUp(int odometer, double liters)
        {
            var f = new FillUp(odometer, liters);

            var last = FillUps.LastOrDefault();
            if (last != null) last.Next = f;

            FillUps.Add(f);

            return f;
        }

        public double? AverageKmL
        {
            get
            {
                return null;
            }
        }

    }
}
