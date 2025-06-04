using System;
using System.Collections.Generic;

namespace Ex04.Menus.Interfaces
{
    // Represents a menu item that can have sub-items and an action associated with it
    public class MenuItem
    {
        public string Title { get; }
        private readonly List<MenuItem> r_SubItems = new List<MenuItem>();
        public IMenuActionable ActionToExecute { get; set; }
        
        public MenuItem(string i_Title)
        {
            Title = i_Title;
        }

        public bool IsLeaf
        {
            get
            {
                return r_SubItems.Count == 0;
            }
        }

        public IReadOnlyList<MenuItem> SubItems
        {
            get
            {
                return r_SubItems.AsReadOnly();
            }
        }

        public void AddSubItem(MenuItem i_SubItem)
        {
            r_SubItems.Add(i_SubItem);
        }
        
        public void Show()
        {
            bool isBackOrExitPressed = false;
            
            while (!isBackOrExitPressed)
            {
                printCurrentMenu();

                try
                {
                    int userChoice = getValidateUserChoice();
                    isBackOrExitPressed = handleChoice(userChoice);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }


        private void printCurrentMenu()
        {
            int numOfItems = SubItems.Count;

            Console.Clear();
            Console.WriteLine($"** {Title} **");
            Console.WriteLine(new string('-', Title.Length + 6));

            for (int i = 0; i < numOfItems; i++)
            {
                Console.WriteLine($"{i + 1}. {SubItems[i].Title}");
            }

            Console.WriteLine($"0. {(this is MainMenu ? "Exit" : "Back")}");
            Console.WriteLine($"Please enter your choice (1-{numOfItems} or 0 to {(this is MainMenu ? "Exit" : "go back")})");
        }

        private int getValidateUserChoice()
        {
            string input = Console.ReadLine();

            if(!int.TryParse(input, out int choice) || choice < 0 || choice > SubItems.Count)
            {
                throw new Exception("Invalid input.");
            }
            
            return choice;
        }

        private bool handleChoice(int i_UserChoice)
        {
            bool isBackOrExitPressed = false;

            if (i_UserChoice == 0)
            {
                isBackOrExitPressed = true;
            }
            else
            {
                MenuItem selectedItem = SubItems[i_UserChoice - 1];

                if(!selectedItem.IsLeaf)
                {
                    selectedItem.Show();
                }
                else if(selectedItem.ActionToExecute != null)
                {
                    Console.Clear();
                    selectedItem.ActionToExecute.StartAction();
                    Console.WriteLine();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadKey();
                }
            }

            return isBackOrExitPressed;
        }
    }
}
