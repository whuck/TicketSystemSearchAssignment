using System;
using System.IO;
namespace DotNetDbMidterm
{
    static class Ui
    {
        public static void DisplayMenu(string arg){
            Console.WriteLine("What would you like to do?");
            switch(arg) {
                case "title" : 
                    TitleScreen();
                    break;
                case "main" : 
                    MainMenu();
                    break;
                case "display" : 
                    DisplayMenu();
                    break;
                case "create" : 
                    CreateMenu();
                    break;
                default : break;
            }

        }
        private static void TitleScreen() {
            Console.WriteLine("Welcome to TicketFest! v2.0");
        }
        private static void MainMenu() {
            Console.WriteLine("[1] Display Tickets");
            Console.WriteLine("[2] Create Ticket");
            Console.WriteLine("[0] Quit");
        }
        private static void DisplayMenu() {
            Console.WriteLine("[1] Display All Tickets");
            Console.WriteLine("[2] Display Bug Tickets");
            Console.WriteLine("[3] Display Enhancement Tickets");
            Console.WriteLine("[4] Display Task Tickets");
            Console.WriteLine("[0] Back to Main Menu");
        }
        private static void CreateMenu() {
            Console.WriteLine("[1] Create New Bug Ticket");
            Console.WriteLine("[2] Create New Enhancement Ticket");
            Console.WriteLine("[3] Create New Task Ticket");
            Console.WriteLine("[0] Back to Main Menu");
        }
    }
}