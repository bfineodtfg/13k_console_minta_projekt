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
                            Console.Clear();
                            string text = "Regisztráció";
                            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, 1);
                            Console.Write(text);

                            Console.SetCursorPosition(10, 3);
                            Console.Write("Felhasználónév: ");
                            string username = Console.ReadLine();

                            Console.SetCursorPosition(10, 5);
                            Console.Write("Jelszó: ");
                            string password = Console.ReadLine();

                            req.Registration(username, password);

                            Console.ReadKey();
                            ReDrawMenu();

                        }
                        break;
                    case 3:
                        Console.Clear();
                        {

                            string text = "Bejelentkezés";
                            Console.SetCursorPosition(Console.WindowWidth / 2 - text.Length / 2, 1);
                            Console.Write(text);

                            Console.SetCursorPosition(10, 3);
                            Console.Write("Felhasználónév: ");
                            string username = Console.ReadLine();

                            Console.SetCursorPosition(10, 5);
                            Console.Write("Jelszó: ");
                            string password = Console.ReadLine();

                            req.Login(username, password);

                            Console.ReadKey();

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
                        req.GetPersonalFruits()
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }
}
