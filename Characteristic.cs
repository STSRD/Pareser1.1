using System;
using System.Collections.Generic;
using System.Text;

namespace Практика
{
    struct Characteristic
    {
        public string Tipe;
        public int Cost;
        public int DestrIncome;
        public int Heals;
        public int RangeAttack;
        public Damage DamageSolders;
        public Damage DamageBuilding;
        public int AttackSpeed;
        public float ReloadingAttack;
        public float TimeTraining;
        public Enum TipeAttack;
        public Enum Missile;
        public int GoldIncome;
        public int GoldIncomeReloading;
        public string Bonus;
        public float TimeBuild;

        public Characteristic(string Tipe,
        int Cost,
        int DestrIncome,
        int Heals,
        int RangeAttack,
        string DamageSolders,
        string DamageBuilding,
        int AttackSpeed,
        int ReloadingAttack,
        float TimeTraining,
        Enum TipeAttack,
        Enum Missile,
        int GoldIncome,
        int GoldIncomeReloading,
        string Bonus,
        float TimeBuild)
        {
            this.Tipe = Tipe;
            this.Cost = Cost;
            this.DestrIncome = DestrIncome;
            this.Heals = Heals;
            this.RangeAttack = RangeAttack;
            this.DamageSolders = new Damage(DamageSolders);
            this.DamageBuilding = new Damage(DamageBuilding);
            this.AttackSpeed = AttackSpeed;
            this.ReloadingAttack = ReloadingAttack;
            this.TimeTraining = TimeTraining;
            this.TipeAttack = TipeAttack;
            this.Missile = Missile;
            this.GoldIncome = GoldIncome;
            this.GoldIncomeReloading = GoldIncomeReloading;
            this.Bonus = Bonus;
            this.TimeBuild = TimeBuild;
        }

        public void viv()
        {
            Console.WriteLine(Tipe);
            Console.WriteLine(Cost);
            Console.WriteLine(DestrIncome);
            Console.WriteLine(Heals);
            Console.WriteLine(RangeAttack);
            DamageSolders.viv();
            DamageBuilding.viv();
            Console.WriteLine(ReloadingAttack);
            Console.WriteLine(TimeTraining);
            Console.WriteLine(TipeAttack);
            Console.WriteLine(Missile);
            Console.WriteLine(GoldIncome);
            Console.WriteLine(GoldIncomeReloading);
            Console.WriteLine(Bonus);
            Console.WriteLine(TimeBuild);

        }
    }
}
