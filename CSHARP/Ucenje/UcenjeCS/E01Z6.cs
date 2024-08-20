using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E01Z6
    {

        //Program od korisnika učitava ime grada i broj stanovnika.
        //Ispisuje rečenicu: U XXXXXXX živi XXXXX ljudi.
        internal static void Izvedi()
        {
            Console.WriteLine("Upiši ime grada");
            string ime= Console.ReadLine();
            Console.WriteLine("Upiši broj stanovnika");
            int bs=int.Parse(Console.ReadLine());
            Console.WriteLine("U {0} živi {1} broj stanovnika",ime,bs);
        }


    }
}
