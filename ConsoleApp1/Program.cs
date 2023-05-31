using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp1
{
    public static class Program
    {

        public static List<SpaceShip> SpaceShips = new List<SpaceShip>();
        public static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            LoadShips();
            

            bool IsExit = false;

            while (!IsExit)
            {
                DisplayMenu();
                Console.Write("Choose action -> ");
                var choose = Console.ReadLine();
                switch (choose)
                {

                    case "1":
                        {
                            CreateShip();
                            Console.Clear();
                            break;
                        }
                    case "2":
                        {
                            Console.Clear();
                            ShowShips();
                            break;
                        }
                    case "3":
                        {
                            EditShip();
                            Console.Clear();
                            break;
                        }
                    case "4":
                        {
                            SaveShip();
                            Console.Clear();
                            break;
                        }
                    case "5":
                        {
                            Console.Clear();
                            Console.WriteLine("Goodbye");
                            IsExit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong action");
                            break;
                        }

                }

            }
        }

        public static void CreateShip()
        {
            
            SpaceShip Ship = new SpaceShip();
            Console.WriteLine("Enter ship name");
            Ship.Name =Console.ReadLine();
            Console.WriteLine("Enter type ship");
            Ship.Type =Console.ReadLine();
            Console.WriteLine("Enter ship speed");
            Ship.Speed =int.Parse( Console.ReadLine());
            Console.WriteLine("Enter amout fuel ship");
            Ship.Vfuel =int.Parse(Console.ReadLine());
            Ship.Refuel = Ship.Speed/(Ship.Vfuel / 2);

            SpaceShips.Add(Ship);

        }
        public static void DisplayMenu()
        {

            Console.WriteLine("1: create ship");
            Console.WriteLine("2: show all ships");
            Console.WriteLine("3: edit ships");
            Console.WriteLine("4: save ships");
            Console.WriteLine("5: exit");

        }

        public static void ShowShips() {
            Console.WriteLine("------------------");
           for(int i = 0;i < SpaceShips.Count; i++)
                Console.WriteLine($"{i+1}. " + SpaceShips[i]);
            Console.WriteLine("------------------");

        }

        public static void EditShip()
        {

            Console.WriteLine("Choose ship");
            var index = int.Parse(Console.ReadLine());
            var Ship = SpaceShips[index-1];

            Console.WriteLine("Enter ship edit name");
            Ship.Name = Console.ReadLine();
            Console.WriteLine("Enter edit type ship");
            Ship.Type = Console.ReadLine();
            Console.WriteLine("Enter edit ship speed");
            Ship.Speed = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter edit amout fuel ship");
            Ship.Vfuel = int.Parse(Console.ReadLine());
            Ship.Refuel = Ship.Speed / (Ship.Vfuel / 2);

            
        }

        public static void SaveShip()
        {
            var Ships = new List<string>();
            for (int i = 0; i < SpaceShips.Count; i++)
                Ships.Add($"{i + 1}. " + SpaceShips[i]);
                File.WriteAllLines("DataShip.txt",Ships);

        }

        public static void LoadShips()
            => File.ReadAllLines("DataShip.txt")
            .Select(SpaceShip.Deserilize).ToList()
            .ForEach(SpaceShips.Add);

    }


}