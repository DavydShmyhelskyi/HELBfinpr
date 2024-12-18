using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPrDotnet
{
    public class Result
    {
        public int id {  get; set; }
        public int testId { get; set; }
        public double resultPercent { get; set; }
        public DateTime finishTime { get; set; }

        public Test Test { get; set; }
    }
}
