using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data
{
    public class ProductCardboardPhase
    {
        public int PCCNumber { get; set; }
        [NotMapped]
        public ProductCardboard ProductCardboard { get; set; }
        public int PhaseId { get; set; }
        [NotMapped]
        public Phase Phase { get; set; }
        public int StatusId { get; set; }
        public PhaseStatus Status { get; set; }
    }
}
