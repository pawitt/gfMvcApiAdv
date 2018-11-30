using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App04.Models
{
    // Model (MVC)
    // Domain Model 
    // Entity (EF)
    public class Truck
    {
        [Key]
        [StringLength(30)]
        public string PlateNo { get; set; }

        [StringLength(50)]
        public string Make { get; set; }


        [StringLength(50)]
        public string DefaultDriverName { get; set; }

        // Navigation properties
        public virtual ICollection<Job> Jobs { get; set; }
           = new HashSet<Job>();
    }
}