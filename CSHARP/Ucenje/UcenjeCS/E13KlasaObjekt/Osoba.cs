using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13KlasaObjekt
{
    // Klasa je opisnik objekta
    internal class Osoba
    {

        // klasa sadrži svojstva (property)
        public string? Ime { get; set; } // OOP princip učahurivanje
        public string? Prezime { get; set; }

        public int Sifra { get; set; } //nema upitnika, ne može biti null

        public Mjesto? Mjesto { get; set; }


        // klasa može sadržavati i metode
        public string ImePrezime()
        {
            return Ime + " " + Prezime;
        }

    }
}
