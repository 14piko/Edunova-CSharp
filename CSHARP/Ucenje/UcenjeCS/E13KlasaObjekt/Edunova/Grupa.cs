using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13KlasaObjekt.Edunova
{
    internal class Grupa
    {

        public int? Sifra { get; set; }
        public string? Naziv { get; set; }

        public Smjer? Smjer { get; set; }

        public string? Predavac { get; set; }

        public int? MaksimalnoPolaznika { get; set; }

        public Polaznik[]? Polaznici { get; set; }

    }
}
