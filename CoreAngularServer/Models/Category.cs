using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngularServer.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<GoodItem> GoodItems { get; set; }
    }
}
