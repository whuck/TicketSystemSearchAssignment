using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;
using NLog.Web;

namespace DotNetDbMidterm
{
    class Program
    {   
        static void Main(string[] args)
        {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            logger.Info("Program started");
            
            //example tickets
            Bug hmm = new Bug("123","summ","status","priority","submitter","assigned","watching","severity");
            Enhancement hmm2 = new Enhancement("123","summ","status","priority","submitter","assigned","watching","software","cost","reason","estimate");
            Task hmm3 = new Task("123","summ","status","priority","submitter","assigned","watching","projectName","duedate");
            
            //var props = typeof(Bug).GetProperties();
            
            //Console.WriteLine("p.asdfasdf");
            //foreach(var p in typeof(Ticket).GetProperties(BindingFlags.NonPublic)) {
            // foreach(var p in typeof(Ticket).GetProperties()) {
            //     Console.WriteLine(p.Name);
            // }
        
           
            //display program title
            Ui.DisplayMenu("title");
            
            //read all the files and dump tickets into TicketList Class
            TicketList.bugs = FileReader.ReadFile("bugs");
            logger.Info(TicketList.bugs.Count+" bug tickets added! next id = " + TicketList.getNextTicketID("bugs"));
            TicketList.enhancements = FileReader.ReadFile("enhancements");
            logger.Info(TicketList.bugs.Count+" enhancement tickets added! next id = " + TicketList.getNextTicketID("enhancements"));
            TicketList.tasks = FileReader.ReadFile("tasks");
            logger.Info(TicketList.bugs.Count+" task tickets added! next id = " + TicketList.getNextTicketID("tasks"));
            
            //loop Main Menu options until quit is selected
            string menuInput = "";
            while (menuInput != "0") {
                Ui.DisplayMenu("main");
                menuInput = Console.ReadLine();
                switch (menuInput) {
                    case "1" :
                        DisplayTickets(); //loops until back to main menu is selected
                        break;
                    case "2" :
                        CreateTickets(); //loops until  back to main menu is selected
                        break;
                    default : break;
                }//switch
            }//while
        }//Main()
        static void DisplayTickets() {
            string menuInput = "";
            while (menuInput != "0") {
                Ui.DisplayMenu("display");
                menuInput = Console.ReadLine();
                //List<Ticket> ticketList = new List<Ticket>();
                switch (menuInput) {
                    case "1" : //display all
                        List<List<Ticket>> allTickets = new List<List<Ticket>>();
                        allTickets.Add(TicketList.bugs);
                        allTickets.Add(TicketList.enhancements);
                        allTickets.Add(TicketList.tasks);
                        Ui.DisplayAllTickets(allTickets);
                        break;
                    case "2" : //display bugs
                        //ticketList = FileReader.ReadFile("bugs");
                        Ui.DisplayTickets(TicketList.bugs,"bugs");
                        break;
                    case "3" : //display enhancement
                        //ticketList = FileReader.ReadFile("enhancements");
                        Ui.DisplayTickets(TicketList.enhancements, "enhancements");
                        break;
                    case "4" : //display task
                        //ticketList = FileReader.ReadFile("tasks");
                        Ui.DisplayTickets(TicketList.tasks,"tasks");
                        break;
                    default : break;
                }//switch
            }//while
        }//displayTickets()
        static void CreateTickets() {
            string menuInput ="";
            while (menuInput != "0") {
                Ui.DisplayMenu("create");
                menuInput = Console.ReadLine();
                switch (menuInput) {
                    case "1" : //create bug
                        CreateTicket("bug");
                        break;
                    case "2" : //create enhancement
                        CreateTicket("enhancement");
                        break;
                    case "3" : //create task
                        CreateTicket("task");
                        break;
                }//switch
            }//while
        }//CreateTickets()
        static Ticket CreateTicket(string type) {
            switch (type) {
                case "bug" : 
                    GetTicketData(typeof(Bug).GetProperties());
                    return null;
                case "enhancement" :
                   return null;
                case "task" :
                return null;
                default : return null;
            }
        }
        static void GetTicketData(PropertyInfo[] props) {
            foreach(var p in props) {
                Ui.GetDetail(p.Name);
            }
        }
    }//class
}//namespace
