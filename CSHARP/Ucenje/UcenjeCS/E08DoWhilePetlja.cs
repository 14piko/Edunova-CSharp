using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E08DoWhilePetlja
    {

        public static void Izvedi()
        {
            // do while izdvaja činjenica da će se on barem jednom izvesti

            int i = 0;

            do
            {
                Console.WriteLine("u do while " + i);
            } while (i > 0);




            // pvjera uvjeta je na ulazu i zato se ne mora izvesti
            while (i > 0) 
            {
                Console.WriteLine("u while " + i);
            }


            // svi ostali elementi kao i u for i while


        }
    }
}
