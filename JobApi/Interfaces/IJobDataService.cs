<<<<<<< HEAD
using JobViewsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobViewsApi.Interfaces
{
    public interface IJobDataService
    {
        Task<IEnumerable<Job>> GetActiveJobs();
        Task<IEnumerable<JobViewItem>> GetJobDataItems();
    }
=======
using JobViewsApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobViewsApi.Interfaces
{
    public interface IJobDataService
    {
        Task<IEnumerable<Job>> GetActiveJobs();
        Task<IEnumerable<JobViewItem>> GetJobDataItems();
    }
>>>>>>> b8ef9e1bfc621577860a6cfbc89b75f90aa25004
}