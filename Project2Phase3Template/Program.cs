using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2Phase3Template
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* 
             * DO NOT EDIT THIS CODE
             * GO DOWN TO END OF CODE
             */
            bool isValid = false;
            string name = "", race = "";    //Give all variables empty/out-of-range values to prevent NullReferenceException
            char gender = '\0';
            int level = -1;

            Console.WriteLine("=========================================");
            Console.WriteLine("| Welcome to the DnD Character Creator! |");
            Console.WriteLine("=========================================\n");

            Console.WriteLine("Please enter your character's name:");
            name = Console.ReadLine();

            do
            {
                Console.WriteLine($"What is {name}'s race? (Choose between Human, Elf, Orc, Dragonborn, or Tiefling");
                race = Console.ReadLine().ToLower();
                if (race == "human" || race == "elf" || race == "orc" || race == "dragonborn" || race == "tiefling")
                    isValid = true;
                else
                    Console.WriteLine("That is not a valid response, try again.");
            } while (!isValid);

            isValid = false;

            do
            {
                Console.WriteLine($"What is {name}'s gender? (Choose between (M)ale, (F)emale, (O)ther, (I)ntersex)");
                isValid = char.TryParse(Console.ReadLine(), out gender);
                gender = char.ToUpper(gender);
                if (isValid && (gender == 'M' || gender == 'F' || gender == 'O' || gender == 'I'))
                {
                    isValid = true;
                }
                else if (race.ToUpper() == "TIEFLING" && char.ToUpper(gender) != 'I') //Bonus
                {
                    Console.WriteLine("Tieflings can only be intersex, try again");
                    isValid = false;
                }
                else
                {
                    Console.WriteLine("That is not a valid response, try again.");
                    isValid = false;
                }
            } while (!isValid);

            isValid = false;

            do
            {
                Console.WriteLine($"What is {name}'s level? (Choose a number no greater than 30)");
                isValid = int.TryParse(Console.ReadLine(), out level);
                if (!(isValid && (level >= 0 && level <= 30)))
                {
                    Console.WriteLine("That is not a valid response, try again.");
                    isValid = false;
                }
            } while (!isValid);
            Console.WriteLine("\n*****************************************\n");
            Console.WriteLine("Thank you, here is your character:");
            Character character = new Character(name, race, gender, level);
            Console.WriteLine(character);
            /* 
             * MAKE ADDITIONS BELOW THIS
             * YOU CAN EDIT BELOW
             */

            /* Generate Random Numbers */

            Random random = new Random();

            int[] diceRolls = new int[6];
            for (int i = 0; i < diceRolls.Length; i++)
            {
                diceRolls[i] = random.Next(1, 21);
            }

            /* Call AssignStats and SetRole */

            character.AssignStats(diceRolls);

            Console.WriteLine(character.ToString());

            character.SetRole();

            Console.WriteLine(character.ToString());
        }
    }
}
