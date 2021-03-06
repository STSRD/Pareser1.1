using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    struct Building
    {
        public object Image;
        public string Name;
        public string Rarity;
        public bool Mythical;
        public List<BuildingDescription> BuildingDescription;

        public Building(object Image,
        string Name,
        string Rarity,
        bool Mythical,
        List<BuildingDescription> BuildingDescription
            ) {
            this.Image = Image;
            this.Name = Name;
            this.Rarity = Rarity;
            this.Mythical = Mythical;

            this.BuildingDescription = BuildingDescription;
        }

    }
}
