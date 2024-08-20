using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E01Z4
    {

        //Program od korisnika učitava dvije rečenice i ispisuje jednu nakon druge u istom retku.

        public static void Izvedi()
        {
            Console.WriteLine("Unesi prvu rečenicu: ");
            
            string recenica1;
            
            recenica1 = Console.ReadLine();

            Console.WriteLine("Unesi drugu rečenicu: ");

            string recenica2 = Console.ReadLine();

            Console.WriteLine(recenica1 + " " + recenica2);

            Console.WriteLine("{0} {1}", recenica1, recenica2);

        }
    }
}
