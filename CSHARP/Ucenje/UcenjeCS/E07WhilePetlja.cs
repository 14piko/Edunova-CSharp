using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E07WhilePetlja
    {

        public static void Izvedi()
        {
            // ponoviti
            // u for petlju se ne mora uopće ući
            int brojDo = 1; // ovo može unijeti korisnik

            for (int i = 1; i < brojDo; i++)
            {
                Console.WriteLine("Kod u petlji for");
            }

            // u while petlju se ne mora ući
            int b = 1;
            while (b < brojDo)
            {
                Console.WriteLine("Kod u petlji while");
            }


            // while radi s bool tipom podatka
            while (true)
            {
                Console.WriteLine("Kod u beskonačnoj petlji while");
                break; // continue radi isto kao i u for
            }


            // ispiši prvih 10 brojeva
            b = 0;
            while (++b < 10)
            {
                Console.WriteLine(b);
                
            }
            Console.WriteLine("Nakon petlje: " + b);



            Console.WriteLine("****************************");

            brojDo = 10;
            b = 1;
            int j = 2;
            while(j>b && j < brojDo) // može ići i || te !
            {
                Console.WriteLine(j++);
            }


            Console.WriteLine("****************************");

            // isto se gnježdi i prekida iz nutra prema van s goto label

        }
    }
}
