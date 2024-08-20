using Newtonsoft.Json;
using System.Xml.Linq;
using UcenjeCS.LjetniRad.FishingAppSummerHomework.Model;

namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Controllers
{
    internal class FishingController
    {
        public List<Fishing> Fishings { get; set; }
        private Menu Menu;
        public FishingController()
        {
            Fishings = new List<Fishing>();
        }
        public FishingController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> Pregled pecanja");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih pecanja");
            Console.WriteLine("\t[2] Unos novog pecanja");
            Console.WriteLine("\t[3] Promjena podataka postojećeg pecanja");
            Console.WriteLine("\t[4] Brisanje pecanja");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowFishing();
                    ShowMenu();
                    break;
                case 2:
                    NewFishing();
                    ShowMenu();
                    break;
                case 3:
                    ChangeFishing();
                    ShowMenu();
                    break;
                case 4:
                    DeleteFishing();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        private void ShowFishing()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> PREGLED PECANJA");
            Console.ForegroundColor = ConsoleColor.White;
           

            if (Fishings.Count <1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTrenutno nema niti jednog pecanja!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var f in Fishings)
                {
                    Console.WriteLine(
                        Environment.NewLine + "Redni broj: [" + ++rb + "]" +
                        Environment.NewLine + "Ime ribe: " + f.Fish?.Name +
                        Environment.NewLine + "Količina ribe: " + f.Quantity +
                        Environment.NewLine + "Ukupna težina ribe: " + f.Weight +
                        Environment.NewLine + "Rijeka: " + f.River?.Name +
                        Environment.NewLine + "Ribolovac: " + f.User?.FirstName + " " + f.User?.LastName +
                        Environment.NewLine + "Datum ulova: " + f.Date +
                        Environment.NewLine + "------------------------------------------------------------------"
                    );
                }

            }

        }
        private void NewFishing()
        {
            ShowFishing();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE PODATKE ZA NOVO PECANJE");
            Console.ForegroundColor = ConsoleColor.White;
            var f = new Fishing();

            int id = Helpers.NumberInput("\tŠifra");
            while (Fishings.Exists(f => f.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }

            f.ID = id;

            Menu.FishController.ShowFish();
            f.Fish = Menu.FishController.Fishes[Helpers.NumberInput("Odaberite redni broj ribe", 1, Menu.FishController.Fishes.Count) - 1];
            f.Quantity = Helpers.NumberInput("\tKoličina ribe", 1, 100);
            f.Weight = Helpers.NumberInput("\tUkupna težina ribe", 1, 1000);

            Menu.RiverController.ShowRiver();
            f.River = Menu.RiverController.Rivers[Helpers.NumberInput("Odaberite redni broj rijeke", 1, Menu.RiverController.Rivers.Count) - 1];

            Menu.UserController.ShowUser();
            f.User = Menu.UserController.Users[Helpers.NumberInput("Odaberite redni broj korisnika", 1, Menu.UserController.Users.Count) - 1];

            f.Date = Helpers.DateInput("\tDatum ulova", false);

            Fishings.Add(f);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNovo pecanje uspješno dodano!");
            Console.ForegroundColor = ConsoleColor.White;
           

            SaveData();
        }
        private void ChangeFishing()
        {
            Console.Clear();
            ShowFishing();
            if (Fishings.Count < 1)
            {
                ShowMenu();
                return;
            }

            var selected = Fishings[Helpers.NumberInput("\nOdaberite redni broj pecanja za promjenu", 1, Fishings.Count) - 1];
            var originalId = selected.ID;

          
            int id = Helpers.NumberInput(originalId, "\tPromjenite šifru pecanja", 1, int.MaxValue);
            while (id != originalId && Fishings.Exists(f => f.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjenite šifru pecanja", 1, int.MaxValue);
            }
            selected.ID = id;

            Menu.FishController.ShowFish();
            selected.Fish = Menu.FishController.Fishes[Helpers.NumberInput(selected.Fish.ID, "\n\tOdaberite ribu koju ste upecali", 1, Menu.FishController.Fishes.Count) - 1];
            selected.Quantity = Helpers.NumberInput(selected.Quantity, "\tPromjenite količinu ribe", 1, 100);
            selected.Weight = Helpers.NumberInput(selected.Weight, "\tPromjenite ukupnu težinu ribe", 1, 1000);

            Menu.RiverController.ShowRiver();
            selected.River = Menu.RiverController.Rivers[Helpers.NumberInput(selected.River.ID, "\n\tOdaberite rijeku na kojoj ste pecali", 1, Menu.RiverController.Rivers.Count) - 1];

            Menu.UserController.ShowUser();
            selected.User = Menu.UserController.Users[Helpers.NumberInput(selected.User.ID, "\n\tOdaberite korisnika", 1, Menu.UserController.Users.Count) - 1];

            selected.Date = Helpers.DateInput(selected.Date, "\tPromjenite datum pecanja", false);

            SaveData();
        }
        private void DeleteFishing()
        {
            Console.Clear();
            ShowFishing();
            if (Fishings.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Fishings[Pomocno.UcitajCijeliBroj("Odaberite redni broj pecanja kojeg želite obrisati",  Fishings.Count) -1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno obrisati pecanje? (DA/NE) (ENTER za prekid)", "da"))
            {
                Fishings.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "fishings.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Fishings));
        }
    }
}