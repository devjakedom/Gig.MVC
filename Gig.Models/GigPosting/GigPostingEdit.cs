using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class GigPostingEdit
    {
        public string JobTitle { get; set; }
        
        public string DescriptionOfJob { get; set; }
        
        public string Location { get; set; }
        
        public int PayPerHour { get; set; }
        public int GigPostId { get; set; }
    }
}
