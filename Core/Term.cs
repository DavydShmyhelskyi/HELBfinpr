using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FnPrDotnet
{
    public class Term
    {
        [Key]
        public int id {  get; set; }
        public string term { get; set; }
        public string definition { get; set; }
        public int termTypeId { get; set; }

        public TermType TermType { get; set; }  
        public ICollection<UserDictionary>  UserDictionaries { get; set; }
    }
}
