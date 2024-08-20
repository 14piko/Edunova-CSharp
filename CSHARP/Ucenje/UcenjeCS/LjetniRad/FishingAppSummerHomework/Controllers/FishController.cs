using Newtonsoft.Json;
using UcenjeCS.LjetniRad.FishingAppSummerHomework.Model;

namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Controllers
{
    internal class FishController
    {
        public List<Fish> Fishes { get; set; }
        private Menu Menu;
        public FishController()
        {
            Fishes = new List<Fish>();
        }
        public FishController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> Ribe");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih riba");
            Console.WriteLine("\t[2] Unos nove ribe");
            Console.WriteLine("\t[3] Promjena podataka postojeće ribe");
            Console.WriteLine("\t[4] Brisanje ribe");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowFish();
                    ShowMenu();
                    break;
                case 2:
                    NewFish();
                    ShowMenu();
                    break;
                case 3:
                    ChangeFish();
                    ShowMenu();
                    break;
                case 4:
                    DeleteFish();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        public void ShowFish()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> POPIS RIBA");
            Console.ForegroundColor = ConsoleColor.White;
           

            if (Fishes.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTrenutno nema ni jedne ribe");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var s in Fishes)
                {
                    Console.WriteLine("\t[" + ++rb + "]" + " Ime ribe: " + s.Name + " | Početak lova: " + s.HuntStart + " | Kraj lova: " + s.HuntEnd + " | Opis: " + s.Description);
                }
            }

        }
        private void NewFish()
        {
            ShowFish();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE PODATKE ZA NOVU RIBU");
            Console.ForegroundColor = ConsoleColor.White;
            var m = new Fish();

            int id = Helpers.NumberInput("\tŠifra");
            while (Fishes.Exists(m => m.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }

            m.Name = Helpers.StringInput("\tNaziv", 64);
            m.HuntStart = Helpers.DateInput("\tDatum početka lova", false);
            m.HuntEnd = Helpers.DateInput("\tDatum kraja lova", false);
            m.Description = Helpers.StringInput("\tOpis", 50);
            Fishes.Add(m);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNova riba je uspješno dodan. (ID: {0} - Riba: {1})", m.ID, m.Name);
            Console.ForegroundColor = ConsoleColor.White;
            m.ID = id;

     
            SaveData();
        }
        private void ChangeFish()
        {
            Console.Clear();
            ShowFish();
            if (Fishes.Count < 1)
            {
                ShowMenu();
                return;
            }

            var selected = Fishes[Helpers.NumberInput("\nOdaberite redni broj ribe za promjenu", 1, Fishes.Count) - 1];
            var originalId = selected.ID;

          
            int id = Helpers.NumberInput(originalId, "\tPromjeni šifru ribe", 1, int.MaxValue);
            while (id != originalId && Fishes.Exists(p => p.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjeni šifru ribe", 1, int.MaxValue);
            }
            selected.ID = id;

            selected.Name = Helpers.StringInput(selected.Name, "\tPromijeni ime ribe", 50, false);
            selected.HuntStart = Helpers.DateInput(selected.HuntStart, "\tPromijeni datum početka lova",  false);
            selected.HuntEnd = Helpers.DateInput(selected.HuntEnd, "\tPromijeni datum kraja lova", false);
            selected.Description = Helpers.StringInput(selected.Description, "\tPromijeni opis ribe", 50, false);

            SaveData();
        }
        private void DeleteFish()
        {
            Console.Clear();
            ShowFish();
            if (Fishes.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Fishes[Pomocno.UcitajCijeliBroj("Odaberi redni broj ribe koju želite obrisati",  Fishes.Count) - 1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno obrisati " + selected.Name + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Fishes.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "fishes.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Fishes));
        }
    }
}