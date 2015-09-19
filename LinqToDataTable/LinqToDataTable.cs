#region Using

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

#endregion

namespace LinqToDataTable
{
    public static class LinqToDataTable
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data, Func<PropertyInfo, bool> filter = null)
        {
            if (data == null) return null;
            PropertyInfo[] properties = (typeof (T)).GetProperties();

            using (var table = new DataTable())
            {
                var actualColumns = 0;
                var selectedProperties = new List<PropertyInfo>();

                foreach (PropertyInfo property in properties)
                {
                    if (filter != null && !filter(property)) continue;
                    Type propertyType = property.PropertyType;

                    if ((propertyType.IsGenericType) && (propertyType.GetGenericTypeDefinition() == typeof (Nullable<>)))
                    {
                        propertyType = propertyType.GetGenericArguments()[0];
                    }

                    table.Columns.Add(property.Name, propertyType);
                    actualColumns++;
                    selectedProperties.Add(property);
                }

                var values = new object[actualColumns];
                foreach (T item in data.Where(item => item != null))
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