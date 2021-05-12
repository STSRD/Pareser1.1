using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    struct Damage
    {
        public int Min;
        public int Max;

        public Damage(int min, int max) {
            this.Min = min;
            this.Max = max;

        }
        public Damage(string damage)
        {
            string[] maxMinDamage = damage.Split('-');
            this.Min = int.Parse(maxMinDamage[0]);
            this.Max = int.Parse(maxMinDamage[1]);

        }
    }
}
