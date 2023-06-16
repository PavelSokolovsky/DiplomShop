using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public partial class Products
    {
        public int Id { get; set; }
        public string Nmae{ get; set; }
        public string Discription { get; set; }
        public string Barcode { get; set; }
        public decimal Price { get; set; }

    }
}
