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
                List<BuildingDescription> buildingDescriptions = new List<BuildingDescription>();
                for (int j = 0; j < 13; j++)
                {
                    int position = 1 + i * 14 + j;

                    BuildingDescription buildingDescription = new BuildingDescription();
                    buildingDescription.Type = date[8][position];
                    buildingDescription.Cost = int.Parse(date[9][position]);
                    buildingDescription.SellIncome = int.Parse(date[10][position]);
                    buildingDescription.Health = int.Parse(date[11][position]);
                    buildingDescription.AttackRange = int.Parse(date[12][position]);
                    buildingDescription.UnitDamage = new Damage(date[13][position]);
                    buildingDescription.BuildingDamage = new Damage(date[14][position]);
                    buildingDescription.AttackSpeed = int.Parse(date[15][position]);
                    buildingDescription.AttackCooldown = int.Parse(date[16][position]);
                    buildingDescription.RecruitTime = float.Parse(date[17][position]);
                    buildingDescription.TypeAttack = ConvertStringToAttackType(date[18][position]);
                    buildingDescription.Missile = ConvertStringToShellType(date[19][position]);
                    buildingDescription.Income = int.Parse(date[20][position]);
                    buildingDescription.GoldCooldown = int.Parse(date[21][position]);
                    buildingDescription.Bonus = date[22][position];
                    buildingDescription.BuildTime = float.Parse(date[23][position]);
                    buildingDescriptions.Add(buildingDescription);
                }

                //Запись информации о здании
                if (date[5][1+i * 14] != "" && date[5][1 + i * 14] != "-")
                {
                    buildings.Add(new Building(date[1][1 + i * 14], date[2][1 + i * 14], date[4][1 + i * 14], true, buildingDescriptions));
                }
                else {
                    buildings.Add(new Building(date[1][1 + i * 14], date[2][1 + i * 14], date[4][1 + i * 14], false, buildingDescriptions));
                }
            }

            //запись рассы
            Race newRace = new Race(date[0][1], buildings);

            return newRace;
        }
    }
}

