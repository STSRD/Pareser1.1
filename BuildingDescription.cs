using System;
using System.Collections.Generic;
using System.Text;

namespace Practice
{
    struct BuildingDescription
    {
        public string Type;
        public int Cost;
        public int SellIncome;
        public int Health;
        public int AttackRange;
        public Damage UnitDamage;
        public Damage BuildingDamage;
        public int AttackSpeed;
        public float AttackCooldown;
        public float RecruitTime;
        public Enum TypeAttack;
        public Enum Missile;
        public int Income;
        public int GoldCooldown;
        public string Bonus;
        public float BuildTime;

        public BuildingDescription(string Type,
        int Cost,
        int SellIncome,
        int Health,
        int AttackRange,
        string UnitDamage,
        string BuildingDamage,
        int AttackSpeed,
        int AttackCooldown,
        float RecruitTime,
        Enum TypeAttack,
        Enum Missile,
        int Income,
        int GoldCooldown,
        string Bonus,
        float BuildTime)
        {
            this.Type = Type;
            this.Cost = Cost;
            this.SellIncome = SellIncome;
            this.Health = Health;
            this.AttackRange = AttackRange;
            this.UnitDamage = new Damage(UnitDamage);
            this.BuildingDamage = new Damage(BuildingDamage);
            this.AttackSpeed = AttackSpeed;
            this.AttackCooldown = AttackCooldown;
            this.RecruitTime = RecruitTime;
            this.TypeAttack = TypeAttack;
            this.Missile = Missile;
            this.Income = Income;
            this.GoldCooldown = GoldCooldown;
            this.Bonus = Bonus;
            this.BuildTime = BuildTime;
        }
    }
}

