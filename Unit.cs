using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    struct Unit
    {
        public string Name;
        public int AttackRange;
        public float MovementSpeed;
        public int AttackSpeed;
        public float AttackCooldown;
        public AttackType TypeAttack;
        public List<UnitDescription> UnitDescriptions;

        public Unit(
        string Name,
        int AttackRange,
        int MovementSpeed,
        int AttackSpeed,
        float AttackCooldown,
         AttackType TypeAttack,
         List<UnitDescription> UnitDescriptions)
        {
            this.Name = Name;
            this.AttackRange = AttackRange;
            this.MovementSpeed = MovementSpeed;
            this.AttackSpeed = AttackSpeed;
            this.AttackCooldown = AttackCooldown;
            this.TypeAttack = TypeAttack;
            this.UnitDescriptions = UnitDescriptions;
        }
    }
}
