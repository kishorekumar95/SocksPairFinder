using System;
using System.Collections.Generic;
using System.Linq;

namespace SocksPairFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> socksArray = new List<int> { 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 4, 4, 5 };
            var res = 0;
            var quotient = 0;

            var query = socksArray.GroupBy(r => r)
                                    .Select(s => new
                                    {
                                        Value = s.Key,
                                        Count = s.Count(),
                                    });

            var socksList = new List<Socks>();

            foreach (var item in query)
            {
                quotient = Math.DivRem(item.Count, 2, out res);
                socksList.Add(new Socks { Value = item.Value, AvailablePair = quotient, Extra = res });
            }

            foreach (var item in socksList)
            {
                Console.Write("Socks: {0}, Available Pair : {1}, Extras : {2} \n", item.Value, item.AvailablePair, item.Extra);
            }

            Console.ReadKey();
        }

        public class Socks
        {
            public int Value { get; set; }
            public int AvailablePair { get; set; }
            public int Extra { get; set; }
        }
    }
}
