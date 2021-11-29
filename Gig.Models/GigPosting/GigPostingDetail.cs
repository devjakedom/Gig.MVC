using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class GigPostingDetail
    {
        public int GigPostId { get; set; }
        
        //public Guid OwnerId { get; set; }
        
        public string JobTitle { get; set; }
        
        public string DescriptionOfJob { get; set; }
        
        public string Location { get; set; }
        
        public int PayPerHour { get; set; }
    }
}
