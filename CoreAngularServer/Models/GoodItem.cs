using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAngularServer.Models
{
    public class GoodItem
    {
        public GoodItem()
        {
            Pictures = new HashSet<Picture>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string PicURL { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Picture> Pictures { get; set; }
        //public int MainPicture_ID { get; set; }
    }
}
