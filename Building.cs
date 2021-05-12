using System;
using System.Collections.Generic;
using System.Text;

namespace Практика
{
    struct Building
    {
        public object Image;
        public string Name;
        //public int Lvl_to_build;
        public string Rarity;
        public bool Mythical;
        //public int Lvl;
        public List<Characteristic> сharacteristic;

        public Building(object Image,
        string Name,
        string Rarity,
        bool Mythical,
        //int Lvl,
        List<Characteristic> сharacteristic
            ) {
            this.Image = Image;
            this.Name = Name;
            this.Rarity = Rarity;
            this.Mythical = Mythical;
            //this.Lvl = Lvl;
            this.сharacteristic = сharacteristic;
        }

        public void viv()
        {
            Console.WriteLine("image");
            Console.WriteLine(Name);
            Console.WriteLine(Rarity);
            Console.WriteLine(Mythical);
            foreach (var item in сharacteristic)
            {
                item.viv();
            }
        }
    }
}
