using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DataServices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private IWebHostEnvironment _webHostEnvironment;

        private static readonly JobDataItem[] JobItems;

        private readonly ILogger<DataController> _logger;

        public DataController(ILogger<DataController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IEnumerable<JobDisplayItem> Get()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            string contentRootPath = _webHostEnvironment.ContentRootPath;

            using (StreamReader r = new StreamReader($"{contentRootPath}/AppData/test.json"))
            {
                string json = r.ReadToEnd();
                List<JobDataItem> jobItems = JsonConvert.DeserializeObject<List<JobDataItem>>(json);
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new JobDisplayItem
            {
                Date = DateTime.Now.AddDays(index),
                // TemperatureC = rng.Next(-20, 55),
                // Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
