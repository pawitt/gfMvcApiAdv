using App04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace App04.Services
{
    public class JobService<TDbContext>
      : ServiceBase<Job, TDbContext>
      where TDbContext : DbContext

    {
        public JobService(TDbContext db) : base(db)
        {
            //
        }

    }
}
