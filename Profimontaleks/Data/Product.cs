using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profimontaleks.Data
{
    public class Product
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Length { get; set; }
        public double GlassThickness { get; set; }
        public ProductType Type { get; set; }
        public int ProductTypeId { get; set; }
        public ProductCardboard ProductCardboard { get; set; }
    }
}
