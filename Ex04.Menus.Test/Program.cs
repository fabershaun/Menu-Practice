using System;
using Ex04.Menus.Interfaces;

namespace Ex04.Menus.Test
{
    internal class Program
    {
       public static void Main()
        {
            MainMenu interfaceMainMenu = buildInterfaceMenu();
            interfaceMainMenu.Show();

            Console.Clear();
            Console.WriteLine("Now launching delegate-based menu...");
            Console.ReadLine();
        }

        private static MainMenu buildInterfaceMenu()
        {
            MainMenu mainMenu = new MainMenu("Interfaces Main Menu");

            // First submenu for letters and version
            MenuItem lettersMenu = new MenuItem("Letters and Version");

            MenuItem showVersion = new MenuItem("Show Version") { Action = new ShowVersionAction() };

            MenuItem countLowercase = new MenuItem("Count Lowercase Letters") { Action = new CountLowerCaseAction() };

            lettersMenu.AddSubItem(showVersion);
            lettersMenu.AddSubItem(countLowercase);

            // Second submenu for date and time
            MenuItem dateTimeMenu = new MenuItem("Show Current Date/Time");

            MenuItem showDate = new MenuItem("Show Current Date") { Action = new ShowDateAction() };

            MenuItem showTime = new MenuItem("Show Current Time") { Action = new ShowTimeAction() };

            dateTimeMenu.AddSubItem(showDate);
            dateTimeMenu.AddSubItem(showTime);

            // Add submenus to the main menu
            mainMenu.AddSubItem(lettersMenu);
            mainMenu.AddSubItem(dateTimeMenu);

            return mainMenu;
        }
    }
}
