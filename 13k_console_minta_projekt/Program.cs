using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13k_console_minta_projekt
{
    class Program
    {
        static int selectedMenu;
        static HttpRequests req;
        static void Main(string[] args)
        {
            req = new HttpRequests();
            ReDrawMenu();
        }
        static void ReDrawMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Gyümölcsök listázása");
            Console.WriteLine("2. Regisztráció gyümölcs szedésre");
            Console.WriteLine("3. Bejelentkezés meglévő profilba");
            try
            {
                selectedMenu = int.Parse(Console.ReadLine().Trim());
                if (selectedMenu < 1 || selectedMenu > 3)
                    throw new Exception("Érvénytelen szám");
                switch (selectedMenu)
                {
                    case 1:
                        req.listFruits();
                        Console.WriteLine("Folytatáshoz nyomj meg egy gombot");
                        Console.ReadKey();
                        ReDrawMenu();
                        break;
                    case 2:
                        {
                            string[] temp = GetInfo("Regisztráció", "Felhasználónév", "Jelszó");
                            req.Registration(temp[0], temp[1]);
                            Console.ReadKey();
                            ReDrawMenu();
                        }
                        break;
                    case 3:
                        {
                            string[] temp = GetInfo("Bejelentkezés", "Felhasználónév", "Jelszó");
                            req.Login(temp[0], temp[1]);
                            Console.ReadKey();
                            DrawLoginMenu();
                        }
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
                ReDrawMenu();
            }
        }
        public static void DrawLoginMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Saját gyümölcsök listázása");
            Console.WriteLine("2. Új gyümölcs szedése");
            Console.WriteLine("3. Már létező gyümölcs szedése");
            Console.WriteLine("4. Kijelentkezés");
            try
            {
                selectedMenu = int.Parse(Console.ReadLine().Trim());
                if (selectedMenu < 1 || selectedMenu > 3)
                    throw new Exception("Érvénytelen szám");
                switch (selectedMenu)
                {
                    case 1:
                        req.GetPersonalFruits();
                        Console.ReadKey();
                        DrawLoginMenu();
                        break;
                    case 2:
                        {
                            string[] temp = GetInfo("Gyümölcs hozzáadása", "Gyümölcs neve", "Gyümölcs ára", "Gyümölcs súlya");
                            req.AddFruits(temp[0], int.Parse(temp[1]), int.Parse(temp[2]));
                            Console.ReadKey();
                            DrawLoginMenu();
                        }
                        break;
                    case 3:
                        {
                            string[] temp = GetInfo("Gyümölcs szerkesztése", "Gyümölcs neve", "Gyümölcs ára", "Gyümölcs súlya");
                            req.UpdateFruits(temp[0], int.Parse(temp[1]), int.Parse(temp[2]));
                            Console.ReadKey();
                            DrawLoginMenu();
                        }
                        break;
                    case 4:
                        Token.token = null;
                        Console.ReadKey();
                        ReDrawMenu();
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        static string[] GetInfo(string title, string firstData, string secondData, string thirdData = null) {
            Console.Clear();

            Console.SetCursorPosition(Console.WindowWidth / 2 - title.Length / 2, 1);
            Console.Write(title);

            Console.SetCursorPosition(10, 3);
            Console.Write(firstData+": ");
            string name = Console.ReadLine().Trim();

            Console.SetCursorPosition(10, 5);
            Console.Write(secondData + ": ");
            string price = Console.ReadLine().Trim();

            string weight = null;

            if (thirdData != null)
            {
                Console.SetCursorPosition(10, 7);
                Console.Write(thirdData + ": ");
                weight = Console.ReadLine().Trim();
            }
            if (weight == null)
            {
                return new string[] { name, price };
            }
            return new string[] { name, price, weight };
        }

    }
}
