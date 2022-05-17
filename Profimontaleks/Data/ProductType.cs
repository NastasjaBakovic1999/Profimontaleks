using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data
{
    public class ProductType
    {
        public int Id { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}
