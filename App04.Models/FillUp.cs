using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace App04.Models
{
    public class FillUp
    {
        public FillUp(int odometer, double liters)
        {
            Odometer = odometer;
            Liters = liters;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Odometer { get; set; }
        public double Liters { get; set; }

        public virtual FillUp Next { get; set; }

        public double? KmL
        {
            get
            {
                if (Next == null) return null;
                if (Next.Liters == 0) return null;

                return (Next.Odometer - Odometer)
                          / Next.Liters;
            }
        }

    }
}