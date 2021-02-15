using System;

namespace JobViewsApi.Models
{
    ///<summary> Job display/dto object </summary>
    public class JobViewDisplayItem
    {
        public DateTime Date { get; set; }
        public int JobViews { get; set; }
        public int JobViewsPredicted { get; set; }
        public int JobsActives { get; set; }
    }
}
