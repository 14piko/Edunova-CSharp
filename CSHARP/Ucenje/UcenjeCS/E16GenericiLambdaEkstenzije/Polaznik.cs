using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal class Polaznik:Entitet
    {
        
        public string? Ime { get; set; }
        public string? Prezime { get; set; }

        public override void PredstaviSe()
        {
            Console.WriteLine(Sifra + " - " + Ime + " " + Prezime);
        }
    }
}
