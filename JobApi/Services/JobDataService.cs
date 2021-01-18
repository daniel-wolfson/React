<<<<<<< HEAD
using JobViewsApi.Interfaces;
using JobViewsApi.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobViewsApi.Services
{
    public class JobDataService : IJobDataService
    {
        private IWebHostEnvironment _webHostEnvironment;

        public JobDataService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary> get all active jobs </summary>
        public async Task<IEnumerable<Job>> GetActiveJobs()
        {
            var results = await GetDataAsync<Job>("jobs");
            return results.Where(x => x.Active);
        }

        /// <summary> get all active jobs </summary>
        public async Task<IEnumerable<JobViewItem>> GetJobDataItems()
        {
            var results = await GetDataAsync<JobViewItem>("jobsData");
            return results;
        }

        /// <summary> get data from json file </summary>
        private async Task<IEnumerable<T>> GetDataAsync<T>(string fileName)
        {
            IEnumerable<T> results = null;
            string webRootPath = _webHostEnvironment.WebRootPath != null ? _webHostEnvironment.WebRootPath + "/" : "";
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            using (StreamReader r = new StreamReader($"{webRootPath}{contentRootPath}/AppData/{fileName}.json"))
            {
                string json = await r.ReadToEndAsync();
                results = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }

            return results ?? new List<T>();
        }
    }
=======
using JobViewsApi.Interfaces;
using JobViewsApi.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobViewsApi.Services
{
    public class JobDataService : IJobDataService
    {
        private IWebHostEnvironment _webHostEnvironment;

        public JobDataService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        /// <summary> get all active jobs </summary>
        public async Task<IEnumerable<Job>> GetActiveJobs()
        {
            var results = await GetDataAsync<Job>("jobs");
            return results.Where(x => x.Active);
        }

        /// <summary> get all active jobs </summary>
        public async Task<IEnumerable<JobViewItem>> GetJobDataItems()
        {
            var results = await GetDataAsync<JobViewItem>("jobsData");
            return results;
        }

        /// <summary> get data from json file </summary>
        private async Task<IEnumerable<T>> GetDataAsync<T>(string fileName)
        {
            IEnumerable<T> results = null;
            string webRootPath = _webHostEnvironment.WebRootPath != null ? _webHostEnvironment.WebRootPath + "/" : "";
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            using (StreamReader r = new StreamReader($"{webRootPath}{contentRootPath}/AppData/{fileName}.json"))
            {
                string json = await r.ReadToEndAsync();
                results = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            }

            return results ?? new List<T>();
        }
    }
>>>>>>> b8ef9e1bfc621577860a6cfbc89b75f90aa25004
}