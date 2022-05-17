using System.Collections.Generic;

namespace Profimontaleks.Data
{
    public class Phase
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<ProductCardboardPhase> ProductCardboards { get; set; }
    }
}
