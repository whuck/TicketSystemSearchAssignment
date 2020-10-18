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
        private static void DisplayTicketHeader(string type) {
            switch (type) {
                case "bugs" :
                    Console.WriteLine("------------------------------Bug Tickets--------------------------------------------------------------");
                    Console.WriteLine($"{"TicketID",8}{"Summary",10}{"Status",7}{"Priority",9}{"Submitter",10}{"Assigned",9}{"Watching",20}{"Severity",9}");
                    Console.WriteLine($"{"--------",8}{"---------",10}{"------",7}{"--------",9}{"---------",10}{"--------",9}{"-------------------",20}{"--------",9}");
                    break;
                case "enhancements" :
                    Console.WriteLine("------------------------------Enhancement Tickets------------------------------------------------------");
                    Console.WriteLine($"{"TicketID",8}{"Summary",10}{"Status",7}{"Priority",9}{"Submitter",10}{"Assigned",9}{"Watching",20}{"Software",9}{"Cost",5}{"Reason",7}{"Estimate",9}");
                    Console.WriteLine($"{"--------",8}{"---------",10}{"------",7}{"--------",9}{"---------",10}{"--------",9}{"-------------------",20}{"--------",9}{"----",5}{"------",7}{"--------",9}");
                    break;
                case "tasks" :
                    Console.WriteLine("------------------------------Task Tickets-------------------------------------------------------------");
                    Console.WriteLine($"{"TicketID",8}{"Summary",10}{"Status",7}{"Priority",9}{"Submitter",10}{"Assigned",9}{"Watching",20}{"Project Name",13}{"DueDate",11}");
                    Console.WriteLine($"{"--------",8}{"---------",10}{"------",7}{"--------",9}{"---------",10}{"--------",9}{"-------------------",20}{"------------",13}{"----------",11}");
                    break;
                default : break;
            }
        }
        private static void DisplayTicketFooter() {
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