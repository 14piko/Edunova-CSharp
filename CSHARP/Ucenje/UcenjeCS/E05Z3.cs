using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E05Z3
    {
        internal static void Izvedi()
        {
            int[,] tablica = {
                {2,2,2 },
                {4,5,6 },
                {2,8,2 }
            };
            //Program ispisuje jedno pokraj drugog odvojeno razmakom brojeve u kutevima tablice.

            Console.WriteLine("{0} {1} {2} {3}", tablica[0,0], tablica[0,2], tablica[2,0], tablica[2,2]);

        }
    }
}
