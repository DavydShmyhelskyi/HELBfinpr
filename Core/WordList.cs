using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class WordList
    {
        public int id { get; set; }
        public int createdBy { get; set; }
        public string name { get; set; }
        public DateTime createdAt { get; set; }

        public User user { get; set; }
        public ICollection<UserDictionary> UserDictionary { get; set; }


    }
}
