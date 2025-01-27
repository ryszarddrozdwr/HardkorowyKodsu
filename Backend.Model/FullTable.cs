namespace BackendClient.Model
{
    public class FullTable
    {
        public int id { get; set; }
        public string sname { get; set; } = string.Empty;
        public string oname { get; set; } = string.Empty;
        public string otype { get; set; } = string.Empty;
        public Column[] columns { get; set; } = new Column[0];
    }
}
