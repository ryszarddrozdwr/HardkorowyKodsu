using BackendClient.Model; 
using HardkorowyKodsuClient.Model;

namespace HardkorowyKodsuClient.Extensions
{
    public static class ApiModelConvertersExtension
    {
        public static TabularItem[] FromTables(this Table[] data)
        {
            var result = new TabularItem[data.Length];
            for(int i = 0; i < data.Length; i++)
            {
                result[i] = new TabularItem
                {
                    ID = data[i].id,
                    Type = "Table",
                    Name = $"{data[i].sname}.{data[i].oname}",
                    Downloaded = false,
                    Columns = Array.Empty<ColumnItem>()
                };
            }
            return result;
        }
        public static TabularItem[] FromViews(this Table[] data)
        {
            var result = new TabularItem[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = new TabularItem
                {
                    ID = data[i].id,
                    Type = "View",
                    Name = $"{data[i].sname}.{data[i].oname}",
                    Downloaded = false,
                    Columns = Array.Empty<ColumnItem>()
                };
            }
            return result;
        }
        public static ColumnItem[] FromColumns(this Column[] data)
        {
            var result = new ColumnItem[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                result[i] = new ColumnItem { Name = data[i].cname };
            }
            return result;
        }
    }
}
