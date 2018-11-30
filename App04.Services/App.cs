//using App04.Services.Northwind.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App04.Services
{
    public abstract class AppBase<TDbContext>
      where TDbContext : DbContext
    {
        protected readonly TDbContext db;

        public AppBase(TDbContext db)
        {
            this.db = db;
        }
        public int SaveChanges() => db.SaveChanges();
        public async Task<int> SaveChangesAsync()
          => await db.SaveChangesAsync();

        public int ExecuteSql(FormattableString sql)
        {
            return db.Database.ExecuteSqlCommand(sql);
        }
    }

    public class App : AppBase<AppDb>
    {
        private Lazy<JobService<AppDb>> _jobs;
        private Lazy<TruckService<AppDb>> _trucks;

        public App(AppDb db) : base(db)
        {
            _jobs = new Lazy<JobService<AppDb>>(() => new JobService<AppDb>(db));
            _trucks = new Lazy<TruckService<AppDb>>(() => new TruckService<AppDb>(db));
        }

        public JobService<AppDb> Jobs => _jobs.Value;
        public TruckService<AppDb> Trucks => _trucks.Value;
    }
    /*
    public class NorthwindApp : AppBase<NorthwindDb>
    {
        public NorthwindApp(NorthwindDb db) : base(db)
        {
        }
    }
    */
}



/*
public class NorthwindApp : AppBase<NorthwindDb>
{
    public NorthwindApp(NorthwindDb db) : base(db)
    {
    }
}
*/
