using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data
{
    public class ProductCardboard
    {
        public int PCCNumber { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<ProductCardboardPhase> Phases { get; set; }
    }
}
