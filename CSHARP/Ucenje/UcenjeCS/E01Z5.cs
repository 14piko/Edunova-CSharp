using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E01Z5
    {





        // Program od korisnika učitava decimalni broj te ispisuje drugi korijen učitanog broja.
        internal static void Izvedi()
        {
            decimal x;
            Console.WriteLine("Unesi decimalni broj: ");
            x = decimal.Parse(Console.ReadLine());
            double y = Math.Sqrt(decimal.ToDouble(x));
            Console.WriteLine(y);

            Console.WriteLine("Unesi decimalni broj: ");
            Console.WriteLine(Math.Sqrt(double.Parse(Console.ReadLine())));

            

        }
    }
}
