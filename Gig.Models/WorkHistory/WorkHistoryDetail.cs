using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class WorkHistoryDetail
    {
        public int WorkHistoryId { get; set; }
        public string Company { get; set; }
        
        [Display(Name = "How long did you work there? (in months/years)")]
        public string TimeWorked { get; set; }
        
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        
        [Display(Name = "Description")]
        public string JobDescription { get; set; }
        public int ProfileId { get; set; }
    }
}
