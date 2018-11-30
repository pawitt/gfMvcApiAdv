using App04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace App04.Services
{
    public class TruckService<TDbContext> : ServiceBase<Truck, TDbContext>
      where TDbContext : DbContext
    {
        public TruckService(TDbContext db) : base(db)
        {
            //
        }

    }
}