using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class GigPostingCreate
    {
        
        [Required]
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name ="Description")]
        public string DescriptionOfJob { get; set; }
        [Required]
        [Display(Name = "Address for gig")]
        public string Location { get; set; }
        [Required]
        [Display(Name = "Hourly Rate")]
        public int PayPerHour { get; set; }
    }
}

