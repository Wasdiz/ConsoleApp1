using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SpaceShip
    {
    public string Name { get; set; }
     public string Type { get; set; }
    public int Speed { get; set; }
    public int Vfuel { get; set; }
    public int Refuel { get; set; }
        public override string ToString()

        {
            return $"{Name} {Type} {Speed} {Vfuel} {Refuel}";
        }

        public static SpaceShip Deserilize(string value)
        {

            var args = value.Split(" ");

            return new SpaceShip()
            {
                
                Name = args[1],
                Type = args[2],
                Speed = int.Parse(args[3]),
                Vfuel = int.Parse(args[4]),
                Refuel = int.Parse(args[5])

            };

        }
    }
    
}
