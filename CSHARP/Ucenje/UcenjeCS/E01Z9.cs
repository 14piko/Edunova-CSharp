using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E01Z9
    {

        // Program učitava od korisnika tri broja.
        // Program ispisuje razliku druga dva broja pribrojeno prvom broju
        internal static void Izvedi()
        {
            int b1;
            Console.WriteLine("Unesi prvi broj: ");
            b1 =int.Parse(Console.ReadLine());
            Console.WriteLine("Unesi drugi broj: ");
            int b2;
            b2=int.Parse(Console.ReadLine());
            int b3;
            Console.WriteLine("Unesi treći broj:");
            b3=int.Parse(Console.ReadLine());

            Console.WriteLine((b2 - b3) + b1);

        }
    }
}
