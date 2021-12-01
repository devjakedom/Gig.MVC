using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class WorkHistoryCreate
    {
        [Required]
        public string Company { get; set; }
        [Required]
        [Display(Name = "How long did you work there? (in months/years)")]
        public string TimeWorked { get; set; }
        [Required]
        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string JobDescription { get; set; }
        [Required]
        public int ProfileId { get; set; }
    }
}
