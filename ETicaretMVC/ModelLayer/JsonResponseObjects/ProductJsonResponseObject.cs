using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.JsonResponseObjects
{
    public class ProductJsonResponseObject
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public short Stock { get; set; }
        public int CategoryId { get; set; }
     
    }
}
