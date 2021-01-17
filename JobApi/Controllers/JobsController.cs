using JobViewsApi.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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
                    jobViewDate = g.Key.ViewDate,
                    jobViewsPredicted = g.Key.item.ViewCountPredicted,
                    jobViews = g.Sum(x => x.ViewCount),
                    activeJobs = activeJobs.Count(x => x.Active)
                })
                .ToList();

            return Ok(results);
        }

    }
}
