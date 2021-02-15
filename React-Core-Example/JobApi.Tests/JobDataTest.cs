using JobViewsApi.Core;
using JobViewsApi.Interfaces;
using JobViewsApi.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace JobViewsApi.Tests
{
    public class JobDataTest : TestWebHost
    {
        private readonly IJobDataService _jobDataService;

        public JobDataTest()
        {
            var testAssembly = typeof(JobDataService).Assembly.Location;
            ApiContext.ServiceScope = ApiContext.HttpContext.RequestServices.CreateScope();
            _jobDataService = ApiContext.HttpContext.RequestServices.GetRequiredService(typeof(IJobDataService)) as IJobDataService;
        }

        [Fact]
        public void GetActiveJobs()
        {
            var results = _jobDataService.GetActiveJobs();
            Assert.NotNull(results);
        }

        [Fact]
        public void GetJobDataItems()
        {
            var results = _jobDataService.GetJobDataItems();
            Assert.NotNull(results);
        }
    }
}
