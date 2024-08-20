
using Newtonsoft.Json;
using System.Xml.Linq;
using UcenjeCS.LjetniRad.FishingAppSummerHomework.Controllers;
using UcenjeCS.LjetniRad.FishingAppSummerHomework.Model;

namespace UcenjeCS.LjetniRad.FishingAppSummerHomework
{
    internal class Menu
    {
        public FishController FishController { get; set; }
        public RiverController RiverController { get; set; }
        public UserController UserController { get; set; }

        public FishingController FishingController { get; set; }
        public Menu()
        {
            FishController = new FishController(this);
            RiverController = new RiverController(this);
            UserController = new UserController(this);
            FishingController = new FishingController(this);

            LoadData();
            WelcomeMessage();
            ShowMenu();
        }

        private void LoadData()
        {
            var files = new Dictionary<string, Action<string>>
            {
                { "users.json", path => UserController.Users = LoadFromFile<List<User>>(path) },
                { "fishes.json", path => FishController.Fishes = LoadFromFile<List<Fish>>(path) },
                { "rivers.json", path => RiverController.Rivers = LoadFromFile<List<River>>(path) },
                { "fishings.json", path => FishingController.Fishings = LoadFromFile<List<Fishing>>(path) }
            };
            foreach (var file in files)
            {
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), file.Key)))
                {
                    file.Value(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), file.Key));
                }
            }
        }
        private PATH LoadFromFile<PATH>(string filePath)
        {
            using (var file = new StreamReader(filePath))
            {
                string json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<PATH>(json);
            }
        }


        private void ShowMenu()
        {
            Console.Title = "Fishing APP ";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> GLAVNI IZBORNIK");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Ribe");
            Console.WriteLine("\t[2] Rijeke");
            Console.WriteLine("\t[3] Korisnici");
            Console.WriteLine("\t[4] Pecanje");
            Console.WriteLine("\t[5] Izlaz iz programa");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    FishController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    RiverController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 3:
                    Console.Clear();
                    UserController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    FishingController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t**********************************************");
                    Console.WriteLine("\t*  Hvala na korištenju aplikacije! *");
                    Console.WriteLine("\t**********************************************\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        private void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t*********************************");
            Console.WriteLine("\t***** Fishing APP *****");
            Console.WriteLine("\t*********************************");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}