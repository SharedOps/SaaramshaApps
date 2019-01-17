using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaramshaApps.Models.WebApi
{
    public class SaaramshaProject
    {

        public string ProjectName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}