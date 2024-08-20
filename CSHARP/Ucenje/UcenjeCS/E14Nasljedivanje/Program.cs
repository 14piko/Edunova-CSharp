using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E14Nasljedivanje
{
    internal class Program
    {

        // konstruktor - posenba vrsta metode koja se poziva prilikom kreiranje instance klase - objekta
        // ključna riječ new
        // konstruktor se naziva kao i klasa
        public Program() 
        {

            //Console.WriteLine("Hello");
            Smjer s = new Smjer();
            s.Naziv = "Web programiranje";
            Console.WriteLine(s); // ovdje se poziva metoda toString na objektu s

            var p = new Polaznik() { Ime = "Pero", Sifra = 1 };

            Console.WriteLine(p); // ovdje se poziva metoda toString na objektu p

            // apstrakna klasa se ne može instancirati
            //var e = new Entitet(); // e je instanca klase Entitet

            Obrada[] poslovi = new Obrada[2];
            poslovi[0] = new ObradaIzlazniRacun();
            poslovi[1] = new ObradaUlazniRacun();

            // polimorfizam: predstava - realizacija
            foreach(Obrada o in poslovi)
            {
                o.Procesuiraj(); // polimorfizam
            }
            

        }

        // za konstruktor vrijedi pravilo method overloading
        public Program(string s)
        {

            Console.WriteLine(s); 
        
        }
    

    }
}
