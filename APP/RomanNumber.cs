using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP
{
    public class RomanNumber
    {
        public Int32 Value { get; set; }

        public static RomanNumber Parse(string imput)
        {
            return new() { Value = 1 };   
        }
    }
}
