using Faker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E17Subota
{
    internal class Program
    {

        public Program() 
        {

            var ime1 = "ana";
            var ime2 = "ivo";

            bool ispravno = true;

            foreach (var z in ime1)
            {
                if (!char.IsLetter(z)) 
                {
                    ispravno=false; 
                    break;
                }
            }

            if (!ispravno) 
            {
                Console.WriteLine("nije dobro");
                return;
            }


            for(int i = 0; i < 100; i++)
            {
                Console.WriteLine(Faker.Name.FullName(NameFormats.StandardWithMiddleWithPrefix));

            }

            string br = "6";
            int b;
            if (!int.TryParse(br,out b)){
                Console.WriteLine("Ne valja");
            }
            Console.WriteLine(b);

            int kratko;
            int.TryParse("7", out kratko);

            Console.WriteLine(kratko);

        }

      

    }
}
