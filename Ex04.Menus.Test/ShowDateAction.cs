using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    public class ShowDateAction : IMenuActionable
    {
        public void StartAction()
        {
            Console.WriteLine($"Current Date is: {DateTime.Now.ToShortDateString()}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
