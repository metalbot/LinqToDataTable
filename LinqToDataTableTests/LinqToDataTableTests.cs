using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LinqToDataTable;

namespace LinqToDataTableTests
{
    [TestClass]
    public class LinqToDataTableTests
    {
        [TestMethod]
        public void EmptyListReturnsEmptyTable()
        {
            IEnumerable<string> aList = new List<string>();
            var table = aList.ToDataTable();

            Assert.AreEqual(0, table.Rows.Count);
        }

        [TestMethod]
        public void CountsProperties()
        {
            var aList = new List<TwoProperties>
            {
                new TwoProperties()
            };

            var table = aList.ToDataTable();

            Assert.AreEqual(2, table.Columns.Count);
        }

        [TestMethod]
        public void TableColumnsNamedCorrectly()
        {
            var aList = new List<TwoProperties>
            {
                new TwoProperties()
            };

            var table = aList.ToDataTable();

            Assert.AreEqual("Foo", table.Columns[0].ColumnName);
            Assert.AreEqual("AString", table.Columns[1].ColumnName);
        }

        [TestMethod]
        public void CountsRowsCorrectly()
        {
            var aList = new List<TwoProperties>
            {
                new TwoProperties(),
                new TwoProperties(),
                new TwoProperties()
            };

            var table = aList.ToDataTable();

            Assert.AreEqual(3, table.Rows.Count);
        }

        [TestMethod]
        public void FilterRemovesColumns()
        {
            var aList = new List<TwoProperties>
            {
                new TwoProperties()
            };

            var table = aList.ToDataTable( (p) => p.Name.StartsWith("F"));

            Assert.AreEqual(1, table.Columns.Count);
        }

        [TestMethod]
        public void ActsRationallyWithNoProperties()
        {
            var aList = new List<NoProperties>
            {
                new NoProperties(),
                new NoProperties()
            };

            var table = aList.ToDataTable();

            Assert.AreEqual(0, table.Columns.Count);
            Assert.AreEqual(2, table.Rows.Count);
        }
    }

    
}
