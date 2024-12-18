using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class TestType
    {
        public int id {  get; set; }
        public string name { get; set; }

        public ICollection<Test> Tests { get; set; }
    }
}
