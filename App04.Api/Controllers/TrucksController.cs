using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using App04.Api.Models;
using m = App04.Models;
using App04.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace App04.Api.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TrucksController : ControllerBase
    {
        private readonly App app;

        public TrucksController(App app)
        {
            this.app = app;
        }

        [HttpGet("userinfo")]
        public IActionResult UserInfo()
        {
            var lucky = User.Claims
              .SingleOrDefault(x => x.Type == "LuckyNumber").Value;

            return Ok(new
            {
                Name = User.Identity.Name,
                LuckyNumber = lucky
            });
        }

        /// <summary>
        /// Get all trucks.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<IEnumerable<Truck>> GetAllTrucks()
        {
            var trucks = from t in app.Trucks.All
                         orderby t.Make descending
                         select new Truck
                         {
                             PlateNo = t.PlateNo,
                             Make = t.Make,
                             DriverName = t.DefaultDriverName
                         };
            return trucks.ToList();
        }

        [HttpGet("{plateNo}")]
        public ActionResult<Truck> GetById(string plateNo)
        {
            var t = app.Trucks.Find(plateNo);

            return new Truck
            {
                PlateNo = t.PlateNo,
                Make = t.Make,
                DriverName = t.DefaultDriverName
            };
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)] // , Type = typeof(Truck))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public ActionResult<Truck> Post(Truck item)
        {
            var obj = new m.Truck();
            obj.PlateNo = item.PlateNo;
            obj.Make = item.Make;
            obj.DefaultDriverName = item.DriverName;

            app.Trucks.Add(obj);
            app.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { plateNo = item.PlateNo }, item);
        }
    }
}