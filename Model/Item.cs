using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oblig1.Model
{
    public class Item
    {
        [Key]
        public int itemid { get; set; }
        public string itemname { get; set; }
        public int itemprice { get; set; }
        public int currentstock { get; set; }
        public string itemtype { get; set; }
        public string pictureURL { get; set; }
    }
}
