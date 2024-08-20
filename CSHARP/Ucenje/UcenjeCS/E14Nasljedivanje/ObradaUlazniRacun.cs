using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E14Nasljedivanje
{
    // polimorfizam: pozornica
    internal class ObradaUlazniRacun : Obrada
    {
        public override void Procesuiraj()
        {
            Console.WriteLine("1. Vidi koji je iznos");
            Console.WriteLine("2. Plati račun");
        }
    }
}
