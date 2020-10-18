using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;

namespace DotNetDbMidterm
{
    class Program
    {   
        //Main Program
        //contains static logger object, static TicketList object for storing all the ticket objects created
        //contains menu loops for displaying / creating tickets
        public static string path = Directory.GetCurrentDirectory() + "\\nlog.config";
        public static NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
        static void Main(string[] args)
        {
            // create instance of Logger
            //string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            //var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            logger.Info("Program started");
            
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
                }
            }
        }
        //display tickets in TicketList, which tickets based on user input
        static void DisplayTickets() {
            string menuInput = "";
            while (menuInput != "0") {
                Ui.DisplayMenu("display");
                menuInput = Console.ReadLine();
                switch (menuInput) {
                    case "1" : //display all
                        List<List<Ticket>> allTickets = new List<List<Ticket>>();
                        allTickets.Add(TicketList.bugs);
                        allTickets.Add(TicketList.enhancements);
                        allTickets.Add(TicketList.tasks);
                        Ui.DisplayAllTickets(allTickets);
                        break;
                    case "2" : //display bugs
                        Ui.DisplayTickets(TicketList.bugs,"bugs");
                        break;
                    case "3" : //display enhancement
                        Ui.DisplayTickets(TicketList.enhancements, "enhancements");
                        break;
                    case "4" : //display task
                        Ui.DisplayTickets(TicketList.tasks,"tasks");
                        break;
                    default : break;
                }
            }
        }
        //display menu to choose what type to create, then create object, add to TicketList, and write to file
        static void CreateTickets() {
            string menuInput ="";
            while (menuInput != "0") {
                Ui.DisplayMenu("create");
                menuInput = Console.ReadLine();
                switch (menuInput) {
                    case "1" : //create bug
                        Bug b = (Bug) CreateTicket("bug");
                        logger.Info($"Bug ticket[{b.TicketID}] created!");
                        TicketList.bugs.Add(b);
                        FileWriter.WriteToFile(b.GetFileLineString(),"bug");
                        break;
                    case "2" : //create enhancement
                        Enhancement e = (Enhancement) CreateTicket("enhancement");
                        logger.Info($"Enhancement ticket[{e.TicketID}] created!");
                        TicketList.enhancements.Add(e);
                        FileWriter.WriteToFile(e.GetFileLineString(),"enhancement");
                        break;
                    case "3" : //create task
                        Task t = (Task) CreateTicket("task");
                        logger.Info($"Task ticket[{t.TicketID}] created!");
                        TicketList.tasks.Add(t);
                        FileWriter.WriteToFile(t.GetFileLineString(),"task");
                        break;
                }
            }
        }
        //Switch what type of ticket to create, get user input, return new ticket obj
        static Ticket CreateTicket(string type) {
            string[] args;
            switch (type) {
                case "bug" : 
                    args = GetTicketData(new string[]{"","Summary","Status","Priority","Submitter","Assigned","Watching","Severity"},"bugs");
                    return new Bug(args[0],args[1],args[2],args[3],args[4],args[5],args[6],args[7]);
                case "enhancement" :
                    args = GetTicketData(new string[]{"","Summary","Status","Priority","Submitter","Assigned","Watching","Software", "Cost", "Reason", "Estimate"},"enhancements");
                    return new Enhancement(args[0],args[1],args[2],args[3],args[4],args[5],args[6],args[7],args[8],args[9],args[10]);
                case "task" :
                    args = GetTicketData(new string[]{"","Summary","Status","Priority","Submitter","Assigned","Watching","ProjectName","DueDate"},"tasks");
                    return new Task(args[0],args[1],args[2],args[3],args[4],args[5],args[6],args[7],args[8]);
                default : return null;
            }
        }
        //loop through passed in ticket properties and get user input,
        static string[] GetTicketData(string[] props,string type) {
            string[] output = new string[props.Length];
            int nextID = TicketList.getNextTicketID(type);
            output[0] = nextID.ToString();
            
            //skip TicketID
            for(int i = 1; i < props.Length; i++) {
                Ui.GetDetailPrompt(props[i]);
                output[i] = Console.ReadLine();
            }
            return output;
        }
    }
}
