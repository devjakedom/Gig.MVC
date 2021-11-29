using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Data
{
    public class WorkHistory
    {
        [Key]
        public int WorkHistoryId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string TimeWorked { get; set; }
        [Required]
        public string JobTitle { get; set; }
        [Required]
        public string JobDescription { get; set; }
        public virtual Profile Profile { get; set; }
        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }
    }
}
