using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
/*
|=======================================================================================|
|		                              Character 	                	                |
|---------------------------------------------------------------------------------------|
| - charName : string				                                                    |
| - race : string				                                                        |
| - gender : char                                                                       |
| - level : int						                                                    |
| - hitPts : int					                                                    |
| - stats : int[6]                                                                      |
| - role : string                                                                       |
|---------------------------------------------------------------------------------------|
| + GetName() : string  			                                                    |
| + GetRace() : string				                                                    |
| + GetGender() : char                                                                  |
| + GetLevel() : int				                                                    |
| + GetHitPts() : int					                                                |
| + SetName(nameP : string) : void                      	                            |
| + SetRace(raceP : string) : void                        	                            |
| + SetGender(genderP : char) : void                                                    |
| + SetLevel(levelP : int) : void	                                                    |
| - SetHitPts() : void		                        		                            |
| + LevelUP() : void                                                                    |
| + ToString() : string			                         	                            |
| + Character()                                                                         |
| + Character(nameP : string, raceP : string, genderP : char, levelP : int) : void      |
| + AssignStats(diceRolls : int[]) : void                                               |
| + SetRole() : void                                                                    |
|=======================================================================================|
*/
namespace Project2Phase3Template
{
    internal class Character
    {
        /* 
         * DO NOT EDIT THIS CODE
         * GO DOWN TO END OF CODE
         */
        private string charName;
        private string race;
        private char gender;
        private int level;
        private int hitPts;
        public string GetName() { return charName; }
        public string GetRace() { return race; }
        public char GetGender() { return gender; }
        public int GetLevel() { return level; }
        public int GetHitPts() { return hitPts; }
        public void SetName(string nameP) { charName = nameP; }
        public void SetRace(string raceP) { race = raceP; }
        public void SetGender(char genderP) { gender = genderP; }
        public void SetLevel(int levelP) { level = levelP; SetHitPts(); }   //SetLevel calls SetHP to update HP every time level is changed
        private void SetHitPts() { hitPts = 10 + (3 * level); }             //HP is based on level; cannot be called by Program
        public void LevelUp() { level++; SetHitPts(); }                     //LevelUp calls SetHP to update HP every time level is changed

        /* Insert Empty Constructor Below */
        public Character()
        {
            charName = "N/A";
            race = "N/A";
            gender = 'Z';
            level = 0;
            SetHitPts();
        }//end constructor

        /* Insert Constructor w/ Arguments Below */
        public Character(string nameP, string raceP, char genderP, int lvlP)            //Constructor is similar, mirroring SetHP's functionality
        {
            charName = nameP;
            race = raceP;
            gender = genderP;
            level = lvlP;
            SetHitPts();
        }//end constructor
        /* 
         * MAKE ADDITIONS BELOW THIS
         * YOU CAN EDIT BELOW
         */

        /* Add new attributes here */
        private int[] stats = new int[6];
        private string role = "Peasant"; //Default role is Peasant




        /* Modify ToString */
        public override string ToString()
        {
            return $"Character Name: {charName}\nRace: {race}\nGender: {gender}\nLevel: {level}\nHP: {hitPts}\nStats: {string.Join(", ", stats)}\nRole: {role}";
        }//end ToString

        /* Create AssignStats method below */
        public void AssignStats(int[] diceRolls)
        {
            if (diceRolls.Length != 6)
            {
                Console.WriteLine("Error: Invalid number of dice rolls");
                return;
            }

            string[] statNames = { "Strength", "Dexterity", "Constitution", "Intelligence", "Wisdom", "Charisma" };

            for (int i = 0; i < diceRolls.Length; i++)
            {
                Console.WriteLine($"\nStats:\n{statNames[0]}: {stats[0]}\n{statNames[1]}: {stats[1]}\n{statNames[2]}: {stats[2]}\n{statNames[3]}: {stats[3]}\n{statNames[4]}: {stats[4]}\n{statNames[5]}: {stats[5]}\n\nCurrent Dice Roll: {diceRolls[i]}\n");
                int assignedStat;

                do
                {
                    Console.WriteLine($"Which stat would you like to assign this dice roll to?\n1 - {statNames[0]}\n2 - {statNames[1]}\n3 - {statNames[2]}\n4 - {statNames[3]}\n5 - {statNames[4]}\n6 - {statNames[5]}");
                    if (!int.TryParse(Console.ReadLine(), out assignedStat) || assignedStat < 1 || assignedStat > 6)
                    {
                        Console.WriteLine("That value is invalid, try again.");
                    }
                } while (assignedStat < 1 || assignedStat > 6);

                stats[assignedStat - 1] = diceRolls[i];
            }
        }
        /* Create SetRole method below */
        public void SetRole()
        {
            string[] statRoles =
            {
        "Barbarian",
        "Fighter",
        "Rogue",
        "Monk",
        "Sorcerer",
        "Wizard",
        "Druid",
        "Cleric",
        "Paladin",
        "Warlock",
        "Bard"
    };

            string[] availableRoles = new string[11]; 
            bool[] statCheck = new bool[6]; 

            int availableRolesCount = 0;

            
            if (stats[0] > 15) 
            {
                availableRoles[availableRolesCount] = statRoles[0]; 
                statCheck[0] = true;
                availableRolesCount++;
            }
            if (stats[1] > 15) 
            {
                availableRoles[availableRolesCount] = statRoles[2]; 
                statCheck[1] = true;
                availableRolesCount++;
            }
            

            
            if (statCheck[0] && statCheck[1]) 
            {
                availableRoles[availableRolesCount] = statRoles[1]; 
                availableRolesCount++;
            }
           
            if (availableRolesCount == 0)
            {
                role = "Peasant";
                return;
            }

            Console.WriteLine("\nChoose from the following roles:");
            for (int i = 0; i < availableRolesCount; i++)
            {
                Console.WriteLine($"{i}: {availableRoles[i]}");
            }

            int chosenRoleIndex;
            while (true)
            {
                Console.Write("Enter the number corresponding to your desired role: ");
                if (!int.TryParse(Console.ReadLine(), out chosenRoleIndex) || chosenRoleIndex < 0 || chosenRoleIndex >= availableRolesCount)
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
                else
                {
                    role = availableRoles[chosenRoleIndex];
                    break;
                }
            }
        }






    }
}
