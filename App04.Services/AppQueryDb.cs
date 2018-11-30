using App04.Models;
using App04.Models.Queries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace App04.Services
{
    public class AppQueryDb : DbContext
    {
        public AppQueryDb()
        {
        }
        public AppQueryDb(DbContextOptions<AppQueryDb> options) : base(options)
        {
            // 
        }

        public DbQuery<JobReport> JobReports { get; set; }

        public IQueryable<JobReport> QueryJobReports()
        {
            //return JobReports.FromSql("SELECT * FROM vw_JobReport");
            return QuerySql<JobReport>($"SELECT * FROM vw_JobReport");
        }

        public IQueryable<T> QuerySql<T>(FormattableString sql) where T : class
        {
            return Query<T>().FromSql(sql);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=TruckDb;Integrated Security=True;");
            }
        }
    }
}