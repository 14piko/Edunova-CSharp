using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E09ForEachPetlja
    {

        public static void Izvedi()
        {
            // foreach je skraćeni for
            // Ispiši svaki znak iz rijećči jedno ispod drugog
            string rijec = "Osijek";

            for (int i = 0; i < rijec.Length; i++)
            {
                Console.WriteLine(rijec[i]);
            }

            foreach(var slovo in rijec){ // foreach radi s nizovima, stringovima (koji su niz znakova), listama, rječnicima, ...
                Console.WriteLine(slovo);
            }
            /* ne ide
            int b = 25252;
            foreach(var b1 in b)
            {

            }
            */
        }
    }
}
