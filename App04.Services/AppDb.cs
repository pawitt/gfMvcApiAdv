using App04.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace App04.Services
{
    public class AppDb : DbContext
    {
        public AppDb()
        {

        }
        public AppDb(DbContextOptions<AppDb> options) : base(options)
        {
            //
        }

        public DbSet<Truck> Trucks { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Windows Authen.
                optionsBuilder.UseSqlServer("Server=DESKTOP-QJLF36M;Database=TruckDb;Integrated Security=True;");

                // SQL Authen.
                // optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=TruckDb;User Id=xx;Password=yy;");
            }
        }
    }
}