using System;
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

    public class NullableProperty
    {
        public Nullable<int> Foo {get; set;}
    }
}
