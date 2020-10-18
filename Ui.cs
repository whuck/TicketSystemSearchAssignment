using System;
using System.Collections.Generic;
using System.IO;
namespace DotNetDbMidterm
{
    static class Ui
    {
        public static void DisplayMenu(string arg) {
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
        public static void DisplayAllTickets(List<List<Ticket>> allTickets) {
            Console.WriteLine("Displaying All Tickets");
            DisplayTickets(allTickets[0],"bugs");
            DisplayTickets(allTickets[1],"enhancements");
            DisplayTickets(allTickets[2],"tasks");
            DisplayTicketFooter();
        }
        public static void DisplayTickets(List<Ticket> tickets,string type) {
                DisplayTicketHeader(type);
                foreach (Ticket ticket in tickets) {
                    DisplayTicket(ticket);
                }
                DisplayTicketFooter();            
        }
        public static void DisplayTicket(Ticket t) {
            //Console.WriteLine("display ticket");
            Console.WriteLine(t.ToString());
        }
        public static void DisplayTicketHeader(string type) {
            Console.WriteLine();
            Console.WriteLine($"----------{type}----------");
        }
        public static void DisplayTicketFooter() {
            Console.WriteLine();
        }
        private static void TitleScreen() {
            Console.WriteLine("Welcome to TicketFest! v2.0");
            Console.WriteLine("What would you like to do?");
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