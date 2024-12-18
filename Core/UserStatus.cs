using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class UserStatus
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
