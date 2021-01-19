using JobViewsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobViewsApi.Interfaces
{
    public interface IJobDataService
    {
        Task<IEnumerable<Job>> GetActiveJobs();
        Task<IEnumerable<JobView>> GetJobDataItems();
    }
}