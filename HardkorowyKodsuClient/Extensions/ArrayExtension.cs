namespace HardkorowyKodsuClient.Extensions
{
    public static class ArrayExtension
    {
        public static T[] AppendTable<T>(this T[] t1, T[] t2)
        {
            var ret = new T[t1.Length + t2.Length];
            t1.CopyTo(ret, 0);
            t2.CopyTo(ret, t1.Length);
            return ret;
        }
    }
}
