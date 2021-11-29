using Gig.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class ProfileListItem
    {
        public Guid OwnerId { get; set; }
        public int ProfileId { get; set; }
       
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        public virtual ICollection<WorkHistory> WorkHistoryListItem { get; set; } = new List<WorkHistory>();
    }
}
