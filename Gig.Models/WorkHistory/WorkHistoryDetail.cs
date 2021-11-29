﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class WorkHistoryDetail
    {
        public int WorkHistoryId { get; set; }
        public string Company { get; set; }
        public string TimeWorked { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public int ProfileId { get; set; }
    }
}
