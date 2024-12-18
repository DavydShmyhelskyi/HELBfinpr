using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class Test
    {
        public int id {  get; set; }
        public int typeId { get; set; }

        public TestType TestType { get; set; }
        public WordList WordList { get; set; }
        
        public ICollection<Result> Results { get; set; }
    }
}
