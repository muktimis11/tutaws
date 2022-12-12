using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutaws
{
    public class ProductCatalogue1
    {
        public string Id { get; set; }
        public string  ISBN { get; set; }
        public string  Title{ get; set; }
        public string Name { get; set; }
        public List<string>  Authors  { get; set; }

    }
}
