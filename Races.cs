using System;
using System.Collections.Generic;
using System.Text;

namespace Практика
{
    struct Races
    {
        public string name;
        public List<Building> buildings;

        public Races(string name, List<Building> buildings) {
            this.name = name;
            this.buildings = buildings;
        }

        public void viv() {
            Console.WriteLine(name);
            foreach (var item in buildings)
            {
                item.viv();
                Console.WriteLine();
            }
        }
    }
}
