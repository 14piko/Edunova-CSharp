using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal class Program
    {

        public Program() 
        { 
        
            // problem nizova: unaprijed moramo znati koliko će imati elemenata

            // u nastavku nastava i u stvarnom životu koristiti čemo List
            // generička lista cijelih brojeva - int
            List<int> brojevi = new List<int>();

            brojevi.Add(1);
            brojevi.Add(2);

            Console.WriteLine(brojevi[0]);

            foreach (int i in brojevi)
            {
                Console.WriteLine(i);
            }

            List<string> imena = new List<string>();

            imena.Add("Pero");
            imena.Add("Marko");

            // functional programing
            imena.ForEach(Console.WriteLine);


            List<Smjer> smjerovi = new List<Smjer>();

            smjerovi.Add(new() { Sifra = 1, Naziv = "Web programiranje" });

            smjerovi.ForEach(Console.WriteLine);


            Obrada<Smjer> os = new Obrada<Smjer>();
            os.ObjektObrade = smjerovi[0];
            os.Obradi();

            Obrada<Polaznik> op = new Obrada<Polaznik>();
            op.ObjektObrade = new() { Sifra = 1, Ime = "Marko", Prezime = "Perić" };
            op.Obradi();


            op = new Obrada<Polaznik>();
            op.Obradi();



            // Lambda expressions

            // klasika
            Console.WriteLine(KlasicnaMetoda(2,2));

            var Zbroj = (int a, int b) => a + b;

            Console.WriteLine(Zbroj(2,2));

            var algoritam = (int x, int y) =>
            {
                var t = ++x - y;
                return t + y;
            };

            Console.WriteLine(algoritam(2,2));
            Console.WriteLine(algoritam(1,1));

            // ekstenzije
            //smjerovi[0].OdradiPosao();
            Smjer s = new Smjer();
            s.Naziv = "WP";

            smjerovi.Add(new() { Sifra = 2, Naziv = "Java programiranje" });

            smjerovi.ForEach(Console.WriteLine);
            smjerovi.Sort();
            Console.WriteLine("***************");
            smjerovi.ForEach(Console.WriteLine);


            os.Lista = smjerovi;

            os.IspisStavaka(mojIspis);

            os.IspisStavaka(drugaMetoda);
            Console.WriteLine();

            os.IspisStavaka(s => {
                Console.WriteLine("Nisam višpe znao kako nazvati metodu: " + s);
            });

            smjerovi.ForEach(s => {
                Console.WriteLine("Vrtim stavke liste");
            });

            smjerovi.ForEach(mojIspis);


            Console.WriteLine(smjerovi.Sum(s => s.Sifra));

        }

        private void mojIspis(Smjer s)
        {
            Console.WriteLine("Prilagođeni ispis " + s.Naziv);
        }

        private void drugaMetoda(Smjer smjer)
        {
            Console.Write(smjer.Sifra);
        }


        private int KlasicnaMetoda(int a, int b)
        {
            return a + b;
        }

    }
}
