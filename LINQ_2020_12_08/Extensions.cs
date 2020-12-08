using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace LINQ_2020_12_08
{
    public static class Extensions
    {
        public static int ToInt(this object val)
        {
            try
            {
                return Convert.ToInt32(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return int.MinValue;
            }
        }
        public static string Left(this string val, int digits)
        {
            Func<int, string, bool> isToLong = (int x, string s) => s.Length < x;
            if (isToLong(digits, val))
            {
                Console.WriteLine("Ilość znaków jest za duża");
                return val;
            }
            return val.Substring(0, digits);
        }
    }
}
