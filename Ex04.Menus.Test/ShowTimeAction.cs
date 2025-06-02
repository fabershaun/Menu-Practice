using System;
using Ex04.Menus.Interfaces;
namespace Ex04.Menus.Test
{
    internal class ShowTimeAction : IMenuActionable 
    {
        public void StartAction()
        {
            Console.WriteLine($"Current Time is: {DateTime.Now.ToShortTimeString()}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
