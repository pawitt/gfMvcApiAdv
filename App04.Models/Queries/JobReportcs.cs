using System;
using System.Collections.Generic;
using System.Text;

namespace App04.Models.Queries
{
    public class JobReport
    {
        public int JobId { get; set; }
        public DateTime Date { get; set; }
        public string TruckPlateNo { get; set; }
        public int? StartOdometer { get; set; }
        public int? EndOdometer { get; set; }
        public int? Distance => EndOdometer - StartOdometer;
        public double? TotalLiters { get; set; }
        public double? AverageKmL { get; set; }

    }
}