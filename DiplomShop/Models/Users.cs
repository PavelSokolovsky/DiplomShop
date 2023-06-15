using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomShop.Models
{
    public partial class Users
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public int Password { get; set; }

    }
}
