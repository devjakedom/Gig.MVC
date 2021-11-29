using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gig.Models
{
    public class GigApplyCreate
    {
      [Required]
        public int GigPostId { get; set; }
        public int ProfileId { get; set; }

    }
}
