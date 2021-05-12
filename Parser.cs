using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Spreadsheets;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Практика
{
    enum AttackType
    {
        range,
        mele
    };

    enum shellType
    {
        nothing,
        arrow,
        bolt,
        magic,
        bomb,

    };

    enum bonus
    {
        add,
        not
    };

    static class Parser
    {
        static private AttackType convertStringToAttackType(string type) {
            switch (type)
            {
                case "Дальняя":
                    return AttackType.range;
                case "Ближняя":
                    return AttackType.mele;
                default:
                    return AttackType.mele;
            }
        }

        static private shellType convertStringToShellType(string type)
        {
            switch (type)
            {
                case "Стрела":
                    return shellType.arrow;
                case "Болт":
                    return shellType.bolt;
                case "Мигия":
                    return shellType.magic;
                case "Бомба":
                    return shellType.bomb;
                default:
                    return shellType.nothing;
            }
        }

        static private bonus convertStringToBonus(string type)
        {
            switch (type)
            {
                case "":
                    return bonus.not;
                default:
                    return bonus.add;
            }
        }

        static public Races ParserBuildings(string link) {
            //возвращаемый массив
            List<Building> building = new List<Building>();

            //Чтение данных
            List<string[]> date = new List<string[]>();
            using (TextFieldParser tfp = new TextFieldParser(link)) {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");

                while (!tfp.EndOfData) {
                    string[] builds = tfp.ReadFields();
                    date.Add(builds);
                }
            }

            //Подсчет строений
            int koll_buildings = date[0].Length / 13;

            //запись списка зданий рассы
            List<Building> buildings = new List<Building>();

            for (int i = 0; i < koll_buildings; i++)
            {
                //запись характеристик зданий
                List<Characteristic> characteristics = new List<Characteristic>();
                for (int j = 0; j < 13; j++)
                {
                    int poz = 1 + i * 14 + j;

                    Characteristic a = new Characteristic();
                    a.Tipe = date[8][poz];

                    try
                    {
                        a.Cost = int.Parse(date[9][poz]);
                    }
                    catch 
                    {
                        a.Cost = 0;
                    }
                    try
                    {
                        a.DestrIncome = int.Parse(date[10][poz]);
                    }
                    catch
                    {
                        a.DestrIncome = 0;
                    }
                    try
                    {
                        a.Heals = int.Parse(date[11][poz]);
                    }
                    catch
                    {
                        a.Heals = 0;
                    }
                    try
                    {
                        a.RangeAttack = int.Parse(date[12][poz]);
                    }
                    catch
                    {
                        a.RangeAttack = 0;
                    }
                    try
                    {
                        a.DamageSolders = new Damage(date[13][poz]);
                    }
                    catch
                    {
                        a.DamageSolders = new Damage("0-0");
                    }
                    try
                    {
                        a.DamageBuilding = new Damage(date[14][poz]);
                    }
                    catch
                    {
                        a.DamageBuilding = new Damage("0-0");
                    }
                    try
                    {
                        a.AttackSpeed = int.Parse(date[15][poz]);
                    }
                    catch
                    {
                        a.AttackSpeed = 0;
                    }
                    try
                    {
                        a.ReloadingAttack = int.Parse(date[16][poz]);
                    }
                    catch
                    {
                        a.ReloadingAttack = 0;
                    }
                    try
                    {
                        a.TimeTraining = float.Parse(date[17][poz]);
                    }
                    catch
                    {
                        a.TimeTraining = 0;
                    }
                    a.TipeAttack = convertStringToAttackType(date[18][poz]);
                    a.Missile = convertStringToShellType(date[19][poz]);
                    try
                    {
                        a.GoldIncome = int.Parse(date[20][poz]);
                    }
                    catch
                    {
                        a.GoldIncome = 0;
                    }
                    try
                    {
                        a.GoldIncomeReloading = int.Parse(date[21][poz]);
                    }
                    catch
                    {
                        a.GoldIncomeReloading = 0;
                    }
                    a.Bonus = date[22][poz];
                    try
                    {
                        a.TimeBuild = float.Parse(date[23][poz]);
                    }
                    catch
                    {
                        a.TimeBuild = 0;
                    }
                    characteristics.Add(a);
                }

                //запись информации о здании
                if (date[5][1+i * 14] != "" && date[5][1 + i * 14] != "-")
                {
                    buildings.Add(new Building(date[1][1 + i * 14], date[2][1 + i * 14], date[4][1 + i * 14], true, characteristics));
                }
                else {
                    buildings.Add(new Building(date[1][1 + i * 14], date[2][1 + i * 14], date[4][1 + i * 14], false, characteristics));
                }
            }

            //запись рассы
            Races races = new Races(date[0][1], buildings);

            return races;



        }
    }
}
