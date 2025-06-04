using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class CountLowerCaseAction : IMenuActionable
    {
        public void StartAction()
        {
            Console.WriteLine("Please enter a sentence:");
            string input = Console.ReadLine();

            int lowercaseCount = 0;

            foreach (char currentChar in input)
            {
                if (char.IsLower(currentChar))
                {
                    lowercaseCount++;
                }
            }

            Console.WriteLine($"The number of lowercase letters in the sentence is: {lowercaseCount}");
        }
    }
}
