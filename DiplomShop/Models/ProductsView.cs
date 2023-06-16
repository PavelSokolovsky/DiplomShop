using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public class ProductsView
    {
        public int id { get; set; }
        public int idUsers { get; set; }
        public string Name{ get; set; }
        public int amountMax { get; set; }
        public int amountMin { get; set; }
        public int amountCurrent { get; set; }
    }
}
