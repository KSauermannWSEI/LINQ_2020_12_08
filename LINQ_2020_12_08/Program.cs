using LINQ_2020_12_08.Data;
using LINQ_2020_12_08.Models.WW;
using LINQ_2020_12_08.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace LINQ_2020_12_08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LINQ World!");
            //display(new List<int> { 1, 2, 6, 89 });
            //InMemory db = new InMemory();

            //var query = from p in db.People
            //            where p.Id < 5 && p.BirthDate.Year >= 2000
            //            select p;
            //display(query.ToList());

            //object obj = new object();
            //obj.ToString();
            //obj.ToInt();
            //int x = 34;
            //string xStr = "34abcdefghijk";
            //double xDouble = 12.7;
            //int y = xStr.ToInt();
            //int x = ToInt(xStr);
            //int z = xDouble.ToInt();

            //Console.WriteLine(xStr.Left(3));

            //Action<string> line = (text) => Console.WriteLine(text);
            //line("Roman");

            //Func<int, int> s = a => a * a;
            //var val = s(2);
            //Console.WriteLine(val);
            //Console.WriteLine(s(5));

            //string name = "Roman";
            //Console.WriteLine(name.Left(2));

            //var query = (from p in db.People
            //             let age = DateTime.Today.Year - p.BirthDate.Year
            //             select $"{p.Name} {p.LastName} Age: {age}").ToList();

            //var queryM = db.People
            //    .Select(p => $"{p.Name} {p.LastName} Age: {DateTime.Today.Year - p.BirthDate.Year}").ToList();

            //var queryM = db.People
            //    .Where(a=>a.BirthDate > new DateTime(1999,1,1) && a.BirthDate < new DateTime(2001, 1, 1))
            //    //.Where(a=>a.BirthDate < new DateTime(2001,1,1))
            //    .Select(p => $"{p.Name} {p.LastName} Age: {DateTime.Today.Year - p.BirthDate.Year}").ToList();

            //var query = (from p in db.People
            //             let age = DateTime.Today.Year - p.BirthDate.Year
            //             //where age > 70
            //             select $"{p.Name} {p.LastName} Age: {age}").ToList();
            //var isAny = query.Any(q=>q.Contains("73"));
            //display(query);
            ////Console.WriteLine(isAny);
            //var all = query.All(q => q.Contains("7"));

            //var contains = query.Contains("Roman Niepołomski Age: 20");
            //Console.WriteLine(contains);

            //var query = from p in db.People
            //            where p.Id > 1
            //            group p by new { p.BirthDate.Year } into g
            //            where g.Count() > 1
            //            select new { g.Key.Year, Count = g.Count() };
            //var queryM = db.People
            //            .Where(p => p.Id > 1)
            //            .GroupBy(p => p.BirthDate.Year)
            //            .Where(g => g.Count() > 1)
            //            .Select(g => new { g.Key, Count = g.Count() });

            //display(query.ToList());
            //display(queryM.ToList());

            //Context context = new Context();
            //db.Cities.ForEach(c => context.Cities.Add(new Models.City { CityName = c.CityName}));
            //db.People.ForEach(p =>
            //{
            //    p.Id = 0;
            //    p.City = context.Cities.First();
            //});
            //context.AddRange(db.People);
            //context.SaveChanges();
            //Console.WriteLine("OK");
            //var peopleAdresses = from p in context.People
            //                     join c in context.Cities
            //                     on p.City.Id equals c.Id into pc
            //                     from c in pc.DefaultIfEmpty()
            //                     select new
            //                     {
            //                         PersonName = $"{p.Name} {p.LastName}",
            //                         c.CityName
            //                     };
            //var methodAdr = context.People
            //                .Join(context.Cities,
            //                p => p.City.Id,
            //                c => c.Id,
            //                (p, c) => new
            //                {
            //                    PersonName = $"{p.Name} {p.LastName}",
            //                    c.CityName
            //                });
            //display(peopleAdresses.ToList());
            //
            WWContext context = new WWContext();
            var temp = context.OrderLines.First();

            Stopwatch stopwatch = new Stopwatch();
            IQueryable<OrderLine> q = context.OrderLines;
            stopwatch.Start();
            var qResult = q.Where(a => a.PickingCompletedWhen > new DateTime(2013, 1, 1) &&
                                       a.PickingCompletedWhen < new DateTime(2016, 1, 1))
                                        .Take(10).ToList();
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Stopwatch stopwatchE = new Stopwatch();
            IEnumerable<OrderLine> e = context.OrderLines;
            stopwatchE.Start();
            var eResult = e.Where(a => a.PickingCompletedWhen > new DateTime(2013, 1, 1) &&
                                       a.PickingCompletedWhen < new DateTime(2016, 1, 1))
                                        .Take(10).ToList();
            stopwatchE.Stop();
            Console.WriteLine(stopwatchE.ElapsedMilliseconds);


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
