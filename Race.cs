using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    struct Race
    {
        public string Name;
        public List<Building> Buildings;
        public List<Unit> Units;

        public Race(string name, List<Building> buildings, List<Unit> Units) {
            this.Name = name;
            this.Buildings = buildings;
            this.Units = Units;

        }

    }
}
