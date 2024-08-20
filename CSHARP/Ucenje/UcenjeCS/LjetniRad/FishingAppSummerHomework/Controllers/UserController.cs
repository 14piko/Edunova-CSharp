using Newtonsoft.Json;
using UcenjeCS.LjetniRad.FishingAppSummerHomework.Model;

namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Controllers
{
    internal class UserController
    {
        public List<User> Users { get; set; }
        private Menu Menu;
        public UserController()
        {
            Users = new List<User>();
        }
        public UserController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> Korisnici");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih korisnika");
            Console.WriteLine("\t[2] Unos novog korisnika");
            Console.WriteLine("\t[3] Promjena podataka postojećeg korisnika");
            Console.WriteLine("\t[4] Brisanje korisnika");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowUser();
                    ShowMenu();
                    break;
                case 2:
                    NewUser();
                    ShowMenu();
                    break;
                case 3:
                    ChangeUser();
                    ShowMenu();
                    break;
                case 4:
                    DeleteUser();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        public void ShowUser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> POPIS KORISNIKA");
            Console.ForegroundColor = ConsoleColor.White;
           

            if (Users.Count <1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTrenutno nema niti jednog korisnika!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var u in Users)
                {
                    Console.WriteLine(
                        Environment.NewLine + "Redni broj: [" + ++rb + "]" +
                        Environment.NewLine + "Ime i prezime korisnika: " + u.FirstName + " " + u.LastName +
                        Environment.NewLine + "Email: " + u.Email +
                        Environment.NewLine + "Oib: " + u.Oib +
                        Environment.NewLine + "Uloga: " + u.Role +
                        Environment.NewLine + "Broj dozvole: " + u.LicenseNumber +
                        Environment.NewLine + "Datum registracije: " + u.CreatedAt +
                        Environment.NewLine + "------------------------------------------------------------------"
                        );
                }

            }

        }
        private void NewUser()
        {
            ShowUser();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE PODATKE ZA NOVOG KORISNIKA");
            Console.ForegroundColor = ConsoleColor.White;
            var u = new User();

            int id = Helpers.NumberInput("\tŠifra");
            while (Users.Exists(r => r.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }
            u.ID = id;

            u.FirstName = Helpers.StringInput("\tIme", 40);
            u.LastName = Helpers.StringInput("\tPrezime", 40);
            u.Email = Helpers.EmailInput("\tEmail", 50, false);
            u.Password = Helpers.PasswordInput(null,"\tLozinka", 4, 50, false);
            u.Oib = Helpers.OibInput(null,"\tOib");
            u.Role = Helpers.StringInput("\tUloga", 30);
            u.LicenseNumber = Helpers.StringInput("\tBroj dozvole", 40);
            u.CreatedAt = Helpers.DateInput("\tDatum kreiranja", false);
            Users.Add(u);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNovi korisnik uspješno dodan. (ID: {0} - Korisnik: {1})", u.ID, u.FirstName + " " + u.LastName);
            Console.ForegroundColor = ConsoleColor.White;
     
            SaveData();
        }
        private void ChangeUser()
        {
            Console.Clear();
            ShowUser();
            if (Users.Count < 1)
            {
                ShowMenu();
                return;
            }

            var selected = Users[Helpers.NumberInput("\nOdaberite redni broj korisnika za promjenu", 1, Users.Count) - 1];
            var originalId = selected.ID;

          
            int id = Helpers.NumberInput(originalId, "\tPromjeni šifru korisnika", 1, int.MaxValue);
            while (id != originalId && Users.Exists(u => u.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Šifra već postoji!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjeni šifru korisnika", 1, int.MaxValue);
            }
            selected.ID = id;

            selected.FirstName = Helpers.StringInput(selected.FirstName,"\tPromijeni ime korisnika", 40, false);
            selected.LastName = Helpers.StringInput(selected.LastName, "\tPromijeni prezime korisnika", 40, false);
            selected.Password = Helpers.PasswordInput(selected.Password, "\tPromjeni lozinku", 4, 50, false);
            selected.Email = Helpers.EmailInput(selected.Email, "\tPromjeni email", 50, false);
            selected.Oib = Helpers.OibInput(selected.Oib, "\tPromijeni oib korisnika");
            selected.Role = Helpers.StringInput(selected.Role, "\tPromijeni ulogu korisnika", 30, false);
            selected.LicenseNumber = Helpers.StringInput(selected.LicenseNumber, "\tPromijeni broj dozvole korisnika", 40, false);
            selected.CreatedAt = Helpers.DateInput(selected.CreatedAt, "\tPromjeni datum kreiranja", false); 

            SaveData();
        }
        private void DeleteUser()
        {
            Console.Clear();
            ShowUser();
            if (Users.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Users[Pomocno.UcitajCijeliBroj("Odaberite redni broj korisnika kojeg želite obrisati",  Users.Count) - 1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno obrisati korisnika " + selected.FirstName + " " + selected.LastName + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Users.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "users.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Users));
        }
    }
}