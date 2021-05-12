using System;
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

        static public List<Building> ParseBuildings(string link) {
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

            return buildings;
        }

        static public List<Unit> ParseUnits(string link)
        {
            //Чтение данных
            List<string[]> date = new List<string[]>();
            using (TextFieldParser tfp = new TextFieldParser(link))
            {
                tfp.TextFieldType = FieldType.Delimited;
                tfp.SetDelimiters(",");

                while (!tfp.EndOfData)
                {
                    string[] units = tfp.ReadFields();
                    date.Add(units);
                }
            }

            //Подсчет существ
            int numberOfUnits = 0;
            for (int i = 1; i < date[26].Length; i++)
            {
                if (date[26][i] != "" && date[26][i] != null) {
                    numberOfUnits++;                
                }
            }

            //Запись списка существ рассы
            List<Unit> Units = new List<Unit>();

            for (int i = 0; i < numberOfUnits; i++)
            {
                //запись характеристик существа
                List<UnitDescription> unitDescriptions = new List<UnitDescription>();
                int position;

                for (int j = 0; j < 13; j++)
                {
                    position = 41 + i * 14 + j;

                    UnitDescription unitDescription = new UnitDescription();
                    unitDescription.Health = int.Parse(date[32][position]);
                    unitDescription.UnitDamage = new Damage(date[33][position]);
                    unitDescription.BuildingDamage = new Damage(date[34][position]);
                    unitDescription.Skill = date[35][position];
                    unitDescriptions.Add(unitDescription);
                }

                //Запись информации о существе
                position = 41 + i * 14;
                Unit newUnit = new Unit();

                newUnit.Name = date[26][position];
                newUnit.AttackRange = int.Parse(date[27][position]);
                newUnit.MovementSpeed = float.Parse(date[28][position]);
                newUnit.AttackSpeed = int.Parse(date[29][position]);
                newUnit.AttackCooldown = float.Parse(date[30][position]);
                newUnit.TypeAttack = ConvertStringToAttackType(date[31][position]);
                newUnit.UnitDescriptions = unitDescriptions;

                Units.Add(newUnit);

            }

            return Units;
        }
    }
}

