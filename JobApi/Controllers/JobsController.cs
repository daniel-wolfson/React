using JobViewsApi.Interfaces;
using JobViewsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobViewsApi.Controllers
{
    [ApiController]
    [Route("api/JobApi/[controller]")]
    public class JobsController : ControllerBase
    {
        private readonly IJobDataService _dataService;
        public JobsController(IJobDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("GetJobs")]
        [SwaggerOperation(Summary = "JobApi GetJobs", Description = "Get jobs from json data file")]
        public async Task<IEnumerable<Job>> GetJobs()
        {
            var activeJobs = await _dataService.GetActiveJobs();
            return activeJobs;
        }

        [HttpGet("GetJobViews")]
        [SwaggerOperation(Summary = "JobApi GetJobViews", Description = "Get job views from json data file")]
        public async Task<IActionResult> GetJobViews()
        {
            var activeJobs = await _dataService.GetActiveJobs();
            var jobDataItems = await _dataService.GetJobDataItems();

            var results = jobDataItems
                .GroupBy(item => new { item.ViewDate, item })
                .Select(g => new
                {
                    viewDate = g.Key.ViewDate,
                    viewsPredicted = g.Key.item.ViewCountPredicted,
                    views = g.Sum(x => x.ViewCount),
                    activeJobs = activeJobs.Count(x => x.Active)
                })
                .ToList();

            return Ok(results);
        }

    }
}
