using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngularServer.Models
{
    public class Picture
    {
        public int ID { get; set; }
        public string pathURL { get; set; }
        //[ForeignKey("GoodItem")]
        public int GoodItemId { get; set; }
        public GoodItem GoodItem { get; set; }
    }
}
