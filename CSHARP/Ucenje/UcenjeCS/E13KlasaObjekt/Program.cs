using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcenjeCS.E13KlasaObjekt.Edunova;

namespace UcenjeCS.E13KlasaObjekt
{
    public class Program
    {

        public static void Izvedi()
        {
            // Objekt je instanca (pojavnost) klase.
            // Osoba je klasa
            // osoba je instanca klase (objekt, varijabla)
            Osoba osoba = new Osoba();

            osoba.Ime = "Pero"; // DZ: Napraviti metodu Pomocno.UcitajString koja osigurava unosa
            osoba.Prezime = "Perić";

            Console.WriteLine(osoba.ImePrezime());

            Osoba ravnatelj = new Osoba
            {
                Ime = "Eduard",
                Prezime = "Kuzma"
            };


            var direktor = new Osoba { Prezime = "Kas" };
            // https://gunnarpeipman.com/csharp-question-marks/
            // https://blog.wordbot.io/tech/what-do-two-question-marks-together-mean-in-c/
            // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators#null-conditional-operators--and-
            Console.WriteLine(direktor.Ime?.ToUpper());


            Osoba o = new()
            {
                Ime = "Ana",
                Prezime = "Kiš"
            };

            o.Mjesto = new() { PostanskiBroj = "31000", 
                Zupanija=new() { 
                    Drzava=new() { Naziv="Hrvatska"} 
                } 
            };

            Console.WriteLine(o.Mjesto?.Naziv?.ToUpper());

            Console.WriteLine(o.Mjesto?.Naziv ?? "Nema");

            Console.WriteLine(o.Mjesto?.Zupanija?.Drzava?.Naziv ?? "ne zna,");



            Smjer smjer = new Smjer();
            smjer.Naziv = "Web programiranje";

            Grupa grupa = new() { Naziv="WP4",Smjer=smjer};

            Console.WriteLine(grupa.Smjer.Naziv);





        }

        

    }
}
