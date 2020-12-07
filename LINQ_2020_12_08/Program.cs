using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_2020_12_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LINQ World!");
        }

        #region helpers
        static void display<T>(List<T> list)
        {
            list.ForEach(obj =>
            {
                if (obj is String || obj is ValueType)
                    Console.Write($"{obj} ");
                else // Is Reference Type
                    obj.GetType().GetProperties().ToList().
                        ForEach(prop => Console.Write($"[{prop.Name}]: {prop.GetValue(obj)} "));
                Console.WriteLine();
            });
        }
        #endregion
    }
}
