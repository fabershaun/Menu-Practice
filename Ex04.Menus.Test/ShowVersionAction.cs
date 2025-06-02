using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class ShowVersionAction : IMenuActionable
    {
        private const string k_AppVersion = "25.2.4.4480";

        public void StartAction()
        {
            Console.WriteLine($"App Version: {k_AppVersion}");
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}
