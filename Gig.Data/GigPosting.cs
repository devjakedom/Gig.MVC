using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Data
{
    public class GigPosting
    {
        [Key]
        public int GigPostId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string  DescriptionOfJob { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int PayPerHour { get; set; }
    }
}
