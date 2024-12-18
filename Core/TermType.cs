using System.ComponentModel.DataAnnotations;

namespace FnPrDotnet
{
    public class TermType
    {
        [Key]
        public int id {  get; set; }
        public string name { get; set; }
        public ICollection<Term> terms { get; set; }
    }
}
