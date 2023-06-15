using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public partial class ProductsInOrders
    {
        public int id { get; set; }
        public int IdProduct { get; set; }
        public int IdOrder { get; set; }
        public int AmountInOrder { get; set; }
        public string ProductName { get; set; }


    }
}
