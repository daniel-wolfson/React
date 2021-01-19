using System;

namespace JobViewsApi.Models
{

    ///<summary> Job data item <summary>
    public class JobView
    {
        public Guid JobId { get; set; }
        public DateTime ViewDate { get; set; }
        public int ViewCount { get; set; }
        public int ViewCountPredicted { get; set; }
    }
}