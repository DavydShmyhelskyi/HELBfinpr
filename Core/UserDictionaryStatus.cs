using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class UserDictionaryStatus
    {
        [Key]
        public int id {  get; set; }
        public string name { get; set; }

        public ICollection<UserDictionary>  UserDictionaries { get; set; }

    }
}
