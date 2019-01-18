using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaramshaApps.Models.WebApi
{
    public class SaaramshaTask
    {
        public int ProjectId { get; set; }

        public string TaskName { get; set; }

        public string TaskDescription { get; set; }

        public int AssignedTo { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public int TaskStatusId { get; set; }

    }
}