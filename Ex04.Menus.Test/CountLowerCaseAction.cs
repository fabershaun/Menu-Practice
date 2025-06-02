using System;
using System.Linq;
using Ex04.Menus.Interfaces;
namespace Ex04.Menus.Test
{
    internal class CountLowerCaseAction : IMenuActionable
    {
        public void StartAction()
        {
            Console.WriteLine("Please enter a sentence");
            string input = Console.ReadLine();

            int lowerCaseCount = input.Count(char.IsLower);

            Console.WriteLine($"The number of lowercase letters in the sentence is: {lowerCaseCount}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
