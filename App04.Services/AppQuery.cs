using App04.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App04.Services
{
    public class AppQuery
    {
        private readonly AppQueryDb db;

        public AppQuery(AppQueryDb db)
        {
            this.db = db;
        }

        public IQueryable<JobReport> JobReport()
        {
            return db.QueryJobReports();
        }
    }
}