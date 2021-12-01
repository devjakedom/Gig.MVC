using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class GigPostingEdit
    {
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        
        [Display(Name = "Description")]
        public string DescriptionOfJob { get; set; }
        
        [Display(Name = "Address for gig")]
        public string Location { get; set; }
        
        [Display(Name = "Hourly Rate")]
        public int PayPerHour { get; set; }
        public int GigPostId { get; set; }
    }
}
