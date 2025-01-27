namespace HardkorowyKodsuClient.Model
{
    public class TabularItem
    {
        public int ID { get; set; }
        public string Type { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public bool Downloaded { get; set; }
        public ColumnItem[] Columns { get; set; } = new ColumnItem[0];
    }
}
