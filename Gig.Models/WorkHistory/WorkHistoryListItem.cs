using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class WorkHistoryListItem
    {
        public int WorkHistoryId { get; set; }
        
        //public Guid OwnerId { get; set; }
       
        public string Company { get; set; }
        
        public string TimeWorked { get; set; }
        
        public string JobTitle { get; set; }
        
        public string JobDescription { get; set; }
    }
}

