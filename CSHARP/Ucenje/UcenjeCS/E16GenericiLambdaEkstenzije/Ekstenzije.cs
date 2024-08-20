using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal static class Ekstenzije
    {
        public static void OdradiPosao(this ISucelje sucelje)
        {
            Console.WriteLine("Krećem");
            sucelje.OdradiPosao();
            Console.WriteLine("Završio");
        }
    }
}
