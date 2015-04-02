using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;



namespace LinqToDataTable
{
    public static class LinqToDataTable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, Func<PropertyInfo, bool> filter =  null)
        {
            var properties = (typeof (T)).GetProperties();
            
            
            using (var table = new DataTable())
            {
                long propertyCount = properties.Length;
                var actualColumns = 0;
                var selectedProperties = new List<PropertyInfo>();

                foreach (var property in properties)
                {
                    if (filter != null && !filter(property)) continue;
                    table.Columns.Add(property.Name, property.PropertyType);
                    actualColumns++;
                    selectedProperties.Add(property);
                }

                var values = new object[actualColumns];
                foreach (var item in data)
                {
                    for (var i = 0; i < values.Length; ++i)
                    {
                        values[i] = selectedProperties[i].GetValue(item);
                    }
                    table.Rows.Add(values);
                }

                return table;
            }
        }
    }
}