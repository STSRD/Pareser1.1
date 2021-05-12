using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    struct Race
    {
        public string Name;
        public List<Building> Buildings;

        public Race(string name, List<Building> buildings) {
            this.Name = name;
            this.Buildings = buildings;
        }

    }
}
