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
            string[] a = damage.Split('-');
            this.Min = int.Parse(a[0]);
            this.Max = int.Parse(a[1]);

        }
    }
}
