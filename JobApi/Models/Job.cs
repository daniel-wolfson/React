using System;

namespace JobViewsApi.Models
{
    ///<summary> Job data item <summary>
    public class Job
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; } = true;
    }
}