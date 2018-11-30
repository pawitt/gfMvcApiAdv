using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using m = App04.Models;

namespace App04.Api.Models
{
    public class Truck
    {

        [Key]
        [StringLength(30)]
        public string PlateNo { get; set; }

        [StringLength(50)]
        public string Make { get; set; }

        [StringLength(50)]
        public string DriverName { get; set; }

    }
}