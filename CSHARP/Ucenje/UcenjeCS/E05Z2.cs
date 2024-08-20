using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    //Definirajte dvodimenzinalni niz od 4 elementa koji su decimalni brojeci.
    // DZ: Korisnik upisuje vrijednosti.
    //Program ispisuje unesene brojeve jedno pokraj drugom odvojeno zarezom.

    internal class E05Z2
    {
        internal static void Izvedi()
        {
            int[,] niz = new int[,] {
            {111,212},
            {303,333}
            };

            Console.WriteLine("{0},{1},{2},{3}", niz[0, 0], niz[0,1], niz[1,0], niz[1,1]);

        }
    }
}
