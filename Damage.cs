using System;
using System.Collections.Generic;
using System.Text;

namespace Практика
{
    struct Damage
    {
        public int min;
        public int max;

        public Damage(int min, int max) {
            this.min = min;
            this.max = max;

        }
        public Damage(string damage)
        {
            string[] a = damage.Split('-');
            this.min = int.Parse(a[0]);
            this.max = int.Parse(a[1]);

        }

        public void viv()
        {
            Console.WriteLine(min + "-" + max);
        }
    }
}
