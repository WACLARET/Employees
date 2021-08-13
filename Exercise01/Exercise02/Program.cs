using System;
using Exercise01.Extension_Methods;

namespace Exercise02
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Number to Convert");
            var number = Console.ReadLine().Replace(",", string.Empty);

            var result = Convert.ToInt64(number).Towards();

            Console.WriteLine(result);

        }
    }
}
