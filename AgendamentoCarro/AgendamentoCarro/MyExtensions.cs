using System;
namespace AgendamentoCarro
{
    public static class MyExtensions
    {
        public static string ToMoeda(this string value)
        {
            return string.Format("{0:C}", value);
        }

        public static string ToMoeda(this decimal value)
        {
            return string.Format("{0:C}", value);
        }

        public static string ToMoeda(this double value)
        {
            return string.Format("{0:C}", value);
        }
    }
}
