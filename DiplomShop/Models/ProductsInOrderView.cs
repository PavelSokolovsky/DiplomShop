using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public partial class ProductsInOrderView
    {
        public int id { get; set; }
        public int idUsers { get; set; }
        public string Name { get; set; }
        public int amountInOrder { get; set; }
    }
}
