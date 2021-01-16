using System;

namespace DataServices
{
    ///<summary> Job data item <summary>
    public class JobDataItem 
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public JobViewStatus JobStatus { get; set; }
        public bool Active { get; set; } = true;
        public int PredictedViewCount { get; set; }
    }
}