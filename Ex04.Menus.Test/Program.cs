using System;
using Ex04.Menus.Interfaces;
using Ex04.Menus.Events;
using InterfacesMainMenu = Ex04.Menus.Interfaces.MainMenu;
using InterfacesMenuItem = Ex04.Menus.Interfaces.MenuItem;
using EventsMainMenu = Ex04.Menus.Events.MainMenu;
using EventsMenuItem = Ex04.Menus.Events.MenuItem;

namespace Ex04.Menus.Test
{
    internal class Program
    {
       public static void Main()
        {
            InterfacesMainMenu interfaceMainMenu = buildInterfaceMenu();
            EventsMainMenu eventMainMenu = buildEventMenu();
          
            interfaceMainMenu.Show();
            eventMainMenu.Show();
        }

        private static InterfacesMainMenu buildInterfaceMenu()
        {
            InterfacesMainMenu mainMenu = new InterfacesMainMenu("Interfaces Main Menu");

            // First submenu for letters and version
            InterfacesMenuItem lettersMenu = new InterfacesMenuItem("Letters and Version");
            InterfacesMenuItem showVersion = new InterfacesMenuItem("Show Version") { ActionToExecute = new ShowVersionAction() };
            InterfacesMenuItem countLowercase = new InterfacesMenuItem("Count Lowercase Letters") { ActionToExecute = new CountLowerCaseAction() };

            lettersMenu.AddSubItem(showVersion);
            lettersMenu.AddSubItem(countLowercase);

            // Second submenu for date and time
            InterfacesMenuItem dateTimeMenu = new InterfacesMenuItem("Show Current Date/Time");
            InterfacesMenuItem showDate = new InterfacesMenuItem("Show Current Date") { ActionToExecute = new ShowDateAction() };
            InterfacesMenuItem showTime = new InterfacesMenuItem("Show Current Time") { ActionToExecute = new ShowTimeAction() };

            dateTimeMenu.AddSubItem(showDate);
            dateTimeMenu.AddSubItem(showTime);

            // Add submenus to the main menu
            mainMenu.AddSubItem(lettersMenu);
            mainMenu.AddSubItem(dateTimeMenu);

            return mainMenu;
        }

        private static EventsMainMenu buildEventMenu()
        {
            // Creating the root
            EventsMainMenu mainMenu = new EventsMainMenu("Events Main Menu");

            // First submenu for date and time
            EventsMenuItem lettersMenu = new EventsMenuItem("Letters and Version");
            EventsMenuItem showVersion = new EventsMenuItem("Show Version");
            EventsMenuItem countLowercase = new EventsMenuItem("Count Lowercase Letters");    

            showVersion.Selected += showVersionItem_Selected;
            countLowercase.Selected += countLowercaseItem_Selected;

            lettersMenu.AddSubItem(showVersion);
            lettersMenu.AddSubItem(countLowercase);

            // Second submenu for date and time
            EventsMenuItem dateTimeMenu = new EventsMenuItem("Show Current Date/Time");
            EventsMenuItem showDate = new EventsMenuItem("Show Current Date");
            EventsMenuItem showTime = new EventsMenuItem("Show Current Time");

            showDate.Selected += showDateItem_Selected;
            showTime.Selected += showTimeItem_Selected;

            dateTimeMenu.AddSubItem(showDate);
            dateTimeMenu.AddSubItem(showTime);

            // Add submenus to the main menu
            mainMenu.AddSubItem(lettersMenu);
            mainMenu.AddSubItem(dateTimeMenu);

            return mainMenu;

        }

        private static void showVersionItem_Selected()
        {
            Console.WriteLine("App Version: 25.2.4.4480");
        }

        private static void countLowercaseItem_Selected()
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

        private static void showDateItem_Selected()
        {
            Console.WriteLine($"Current Date is: {DateTime.Now.ToShortDateString()}");
        }

        private static void showTimeItem_Selected()
        {
            Console.WriteLine($"Current Time is: {DateTime.Now.ToShortTimeString()}");
        }
    }
}
