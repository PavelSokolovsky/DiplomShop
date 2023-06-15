using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public partial class UsersProducts
    {
        public int id { get; set; }
        public int idUsers { get; set; }
        public int idProducts { get; set; }
        public int amountMax { get; set; }
        public int amountMin { get; set; }
        public int amountCurrent { get; set; }
    }
}
