using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class GigPostingListItem
    {

        //public int GigPostingId { get; set; }

        [Display(Name = "Job title")]
        public string JobTitle { get; set; }
        [Display(Name = "Description")]
        public string DescriptionOfJob { get; set; }
        [Display(Name = "Address for gig")]
        public string Location { get; set; }
        [Display(Name = "Hourly rate")]
        public int PayPerHour { get; set; }
        public int GigPostId { get; set; }
    }
}