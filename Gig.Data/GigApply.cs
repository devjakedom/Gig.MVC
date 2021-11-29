using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Data
{
    public class GigApply
    {
        [Key]
        public int GigApplyId { get; set; }

        public virtual GigPosting GigPosting{ get; set; }
        [ForeignKey(nameof(GigPosting))]
        public int GigPostId { get; set; }

        public virtual Profile Profile { get; set; }
        [ForeignKey(nameof(Profile))]
        public int ProfileId { get; set; }

        
        public Guid OwnerId { get; set; }
    }
}
