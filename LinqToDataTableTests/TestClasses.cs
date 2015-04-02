using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToDataTableTests
{
    public class TwoProperties
    {
        public int Foo { get; set; }
        public string AString { get; set; }
    }

    public class NoProperties
    {
        public void Foo()
        {
        }
    }
}
