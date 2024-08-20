using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E06ForPetlja
    {


        public static void Izvedi()
        {

            // Ispiši 10 puta Osijek
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");
            Console.WriteLine("Osijek");

            Console.WriteLine("*************************");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Osijek");
            }

            Console.WriteLine("*************************");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("*************************");
            // Zbrojiti prvih 100 brojeva
            int suma = 0;
            for (int i = 1; i <= 100; i++)
            {
                suma += i;
            }
            Console.WriteLine(suma);

            Console.WriteLine("*************************");
            // ispiši sve parne brojeve od 3 do 29
            // loše rješenje
            for (int i = 4; i < 29; i = i + 2)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*************************");
            int brojOd = 3; // ovo se može učitati od korisnika
            int brojDo = 29; // ovo se može učitati od korisnika
            // u nastavku u kodu nema konstanti
            for (int i = brojOd; i < brojDo; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(i);
                }

            }
            Console.WriteLine("*************************");

            int[] niz = { 2, 3, 2, 3, 2, 2, 3, 34, 4, 5 };

            for (int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }


            Console.WriteLine("*************************");
            // Ispiši sve brojeve od 20 do 10
            for(int i = 20; i >= 10; i--)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("*************************");


            // Ispiši sve prim brojeve od 2 do 14
            int ukupno = 0;
            bool prim;
            for(int i = 2; i < 1400; i++)
            {
                prim = true;
                for(int j = 2; j < i; j++)
                {
                    //Console.WriteLine("{0} % {1} = {2}", i,j,i%j);
                    if(i%j== 0)
                    {
                        prim = false; // 2000000 da li je prim broj
                        // prekini unutarnju petlju jer sve ostale provjere nisu više bitne
                        break;
                    }
                    if (!prim)
                    {
                       ukupno++;
                        //Console.WriteLine("Nepotrebno izvođenje " + ++ukupno);
                    }
                }
                if (prim)
                {
                    Console.WriteLine(i);
                }
            }
            Console.WriteLine("nepotrebno izvodio: " + ukupno);


            Console.WriteLine("*************************");
            // preskakanje petlje
            for (int i = 0; i < 10; i++)
            {
                if (i == 3)
                {
                    continue;
                }
                if (i == 5)
                {
                    break;
                }
                Console.WriteLine(i);
            }


            for (int i = 0; i < 10; i++)
            {
                for(int j=0; j < 10; j++)
                {
                    Console.WriteLine(i*j);
                    // želim prekinuti vanjsku petlju: varijabla i
                    goto labela;
                }
            }



        labela:
            Console.WriteLine("********************");



            // beskonačna petlja
            // Unesi broj između 1 i 10
            /*
            Console.WriteLine(int.MaxValue);
            int max = int.MaxValue;
            Console.WriteLine(max+1);

            int broj;
            for(; ; )
            {
                Console.Write("Unesi broj od 1 do 10: ");
                broj = int.Parse(Console.ReadLine());
                if(broj<1 || broj > 10)
                {
                    Console.WriteLine("Nisi unio broj u rasponu!");
                    continue;
                }
                break;
            }
            Console.WriteLine(broj);
            */

            Console.WriteLine("********************");

            niz = PodaciInt.niz;

            Console.WriteLine(niz.Length);
            /*
            for(int i = 0; i < niz.Length; i++)
            {
                Console.WriteLine(niz[i]);
            }
            */

            // Postoji li dva ista broja? Ako postoji koji je to broj?
            /*
            for(int i = 0; i < niz.Length; i++)
            {
                if (i % 10000 == 0)
                {
                    Console.Write("*");
                }
                for(int j=i+1;j<niz.Length; j++)
                {
                    if (niz[i] == niz[j])
                    {
                        Console.WriteLine(niz[i]);
                        goto kraj;
                    }
                }
            }

            kraj:
            Console.WriteLine("************************");
            */

            string[] imena = PodaciString.Niz;

            Console.WriteLine(imena.Length);

            // string je isto niz, niz znakova
            string grad = "Osijek";

            Console.WriteLine(grad[0]);
            Console.WriteLine(grad[grad.Length-1]);

            // Domaća zadaća. Ispisati tablicu množenja 10x10. Formatirati na ovaj način
            //  1   2   3   4   5  6   7   8   9   10
            //  2   4   6   8  10  12  14  16  18  20
            //  3   6   9  12  15  18  21  24  27  30
            //  4   8  12  16  20  24  28  32  36  40
            //  5  10  15  20  25  30  35  40  45  50
            //  6  12  18  24  30  36  42  48  54  60
            //  7  14  21  28  35  42  49  56  63  70
            //  8  16  24  32  40  48  56  64  72  80
            //  9  18  27  36  45  54  63  72  81  90
            // 10  20  30  40  50  60  70  80  90 100


        }

    }
}
