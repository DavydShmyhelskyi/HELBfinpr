using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class UserDictionary
    {
        [Key]
        public int id {  get; set; }
        public int statusId { get; set; }
        public int termId { get; set; }
        public DateTime lastTestTime { get; set; }

        public UserDictionaryStatus UserDictionaryStatus { get; set; }
        public Term Term { get; set; }
        public ICollection<WordList> WordList { get; set; }
    }
}
