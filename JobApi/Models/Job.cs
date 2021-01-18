<<<<<<< HEAD
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
=======
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
>>>>>>> b8ef9e1bfc621577860a6cfbc89b75f90aa25004
}