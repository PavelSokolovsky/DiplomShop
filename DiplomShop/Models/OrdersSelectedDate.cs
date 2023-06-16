using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public partial class OrdersSelectedDate
    {
        public int Id { get; set; }
        public int idUsers { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}
