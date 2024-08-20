using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal abstract class Entitet
    {
        public abstract void PredstaviSe();
        public int? Sifra { get; set; }
    }
}
