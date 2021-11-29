using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Data
{
    public class Profile
    {
        [Key]
        public int ProfileId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        public virtual ICollection<WorkHistory> WorkHistoryListItem { get; set; } = new List<WorkHistory>();
        public Guid OwnerId { get; set; }
    }
}
