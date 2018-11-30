using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App04.Models.Queries;
using App04.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App04.Api.Controllers
{
    [Route("api/v1/q")]
    [Produces("application/json")]
    [ApiController]
    public class QueriesController : ControllerBase
    {
        private readonly AppQuery queries;

        public QueriesController(AppQuery queries)
        {
            this.queries = queries;
        }

        [HttpGet("JobReport")]
        public ActionResult<IEnumerable<JobReport>> JobReport()
        {
            return queries.JobReport().ToList();
        }
    }
}