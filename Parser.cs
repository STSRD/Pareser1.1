using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Spreadsheets;
using System.IO;
using Microsoft.VisualBasic.FileIO;

namespace Practice
{
    enum AttackType
    {
        Range,
        Melee
    };

    enum ShellType
    {
        Nothing,
        Arrow,
        Bolt,
        Magic,
        Bombshell,

    };

    static class Parser
    {
        static private AttackType ConvertStringToAttackType(string type) {
            switch (type)
            {
                case "Дальняя":
                    return AttackType.Range;
                case "Ближняя":
                    return AttackType.Melee;
                default:
                    return AttackType.Melee;
            }
        }

        static private ShellType ConvertStringToShellType(string type)
        {
            switch (type)
            {
                case "Стрела":
                    return ShellType.Arrow;
                case "Болт":
                    return ShellType.Bolt;
                case "Мигия":
                    return ShellType.Magic;
                case "Бомба":
                    return ShellType.Bombshell;
                default:
                    return ShellType.Nothing;
            }
        }

        static public Race ParseBuildings(string link) {
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
            int numberOfBuildings = date[0].Length / 13;

            //Запись списка зданий рассы
            List<Building> buildings = new List<Building>();

            for (int i = 0; i < numberOfBuildings ; i++)
            {
                //запись характеристик зданя
                List<Characteristic> characteristics = new List<Characteristic>();
                for (int j = 0; j < 13; j++)
                {
                    int position = 1 + i * 14 + j;

                    Characteristic BuildingCharacteristics = new Characteristic();
                    BuildingCharacteristics.Tipe = date[8][position];
                    BuildingCharacteristics.Cost = int.Parse(date[9][position]);
                    BuildingCharacteristics.DestrIncome = int.Parse(date[10][position]);
                    BuildingCharacteristics.Heals = int.Parse(date[11][position]);
                    BuildingCharacteristics.RangeAttack = int.Parse(date[12][position]);
                    BuildingCharacteristics.DamageSolders = new Damage(date[13][position]);
                    BuildingCharacteristics.DamageBuilding = new Damage(date[14][position]);
                    BuildingCharacteristics.AttackSpeed = int.Parse(date[15][position]);
                    BuildingCharacteristics.ReloadingAttack = int.Parse(date[16][position]);
                    BuildingCharacteristics.TimeTraining = float.Parse(date[17][position]);
                    BuildingCharacteristics.TipeAttack = ConvertStringToAttackType(date[18][position]);
                    BuildingCharacteristics.Missile = ConvertStringToShellType(date[19][position]);
                    BuildingCharacteristics.GoldIncome = int.Parse(date[20][position]);
                    BuildingCharacteristics.GoldIncomeReloading = int.Parse(date[21][position]);
                    BuildingCharacteristics.Bonus = date[22][position];
                    BuildingCharacteristics.TimeBuild = float.Parse(date[23][position]);
                    characteristics.Add(BuildingCharacteristics);
                }

                //Запись информации о здании
                if (date[5][1+i * 14] != "" && date[5][1 + i * 14] != "-")
                {
                    buildings.Add(new Building(date[1][1 + i * 14], date[2][1 + i * 14], date[4][1 + i * 14], true, characteristics));
                }
                else {
                    buildings.Add(new Building(date[1][1 + i * 14], date[2][1 + i * 14], date[4][1 + i * 14], false, characteristics));
                }
            }

            //запись рассы
            Race newRace = new Race(date[0][1], buildings);
            return newRace;
        }
    }
}
