using Newtonsoft.Json;
using UcenjeCS.LjetniRad.FishingAppSummerHomework.Model;

namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Controllers
{
    internal class RiverController
    {
        public List<River> Rivers { get; set; }
        private Menu Menu;
        public RiverController()
        {
            Rivers = new List<River>();
        }
        public RiverController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> Rijeke");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih rijeka");
            Console.WriteLine("\t[2] Unos nove rijeke");
            Console.WriteLine("\t[3] Promjena podataka postojeće rijeke");
            Console.WriteLine("\t[4] Brisanje rijeke");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowRiver();
                    ShowMenu();
                    break;
                case 2:
                    NewRiver();
                    ShowMenu();
                    break;
                case 3:
                    ChangeRiver();
                    ShowMenu();
                    break;
                case 4:
                    DeleteRiver();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        public void ShowRiver()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> POPIS RIJEKA");
            Console.ForegroundColor = ConsoleColor.White;
           

            if (Rivers.Count <1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTrenutno nema niti jedne rijeke!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var r in Rivers)
                {
                    Console.WriteLine("\t[" + ++rb + "]" + " Ime rijeke: " + r.Name + " | Duljina rijeke: " + r.Length + " km");
                }
            }

        }
        private void NewRiver()
        {
            ShowRiver();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE PODATKE ZA NOVU RIJEKU");
            Console.ForegroundColor = ConsoleColor.White;
            var r = new River();

            int id = Helpers.NumberInput("\tŠifra");
            while (Rivers.Exists(r => r.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }

            r.Name = Helpers.StringInput("\tNaziv rijeke", 255);
            r.Length = Helpers.StringInput("\tDuljina rijeke", 255);
            Rivers.Add(r);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNova rijeka je uspješno dodana. (ID: {0} - Rijeka: {1})", r.ID, r.Name);
            Console.ForegroundColor = ConsoleColor.White;
            r.ID = id;

     
            SaveData();
        }
        private void ChangeRiver()
        {
            Console.Clear();
            ShowRiver();
            if (Rivers.Count < 1)
            {
                ShowMenu();
                return;
            }

            var selected = Rivers[Helpers.NumberInput("\nOdaberite redni broj rijeke za promjenu", 1, Rivers.Count) - 1];
            var originalId = selected.ID;

          
            int id = Helpers.NumberInput(originalId, "\tPromjeni šifru rijeke", 1, int.MaxValue);
            while (id != originalId && Rivers.Exists(p => p.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjeni šifru rijeke", 1, int.MaxValue);
            }
            selected.ID = id;

            selected.Name = Helpers.StringInput(selected.Name, "\tPromijeni ime rijeke", 255, false);
            selected.Length = Helpers.StringInput(selected.Length, "\tPromijeni duljinu rijeke", 255, false);

            SaveData();
        }
        private void DeleteRiver()
        {
            Console.Clear();
            ShowRiver();
            if (Rivers.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Rivers[Pomocno.UcitajCijeliBroj("Odaberite redni broj rijeke koju želite obrisati",  Rivers.Count) - 1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno obrisati " + selected.Name + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Rivers.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "rivers.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Rivers));
        }
    }
}