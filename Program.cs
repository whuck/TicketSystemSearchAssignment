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
        //contains menu loops for displaying / creating tickets, references for file names, and default data 
        public static string path = Directory.GetCurrentDirectory() + "\\nlog.config";
        public static NLog.Logger logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
        public const string _bugsFile = "Tickets.csv";
        public const string _enhancementsFile = "Enhancements.csv";
        public const string _tasksFile ="Tasks.csv";
        public static string[] _defaultFileData = new string[3]{
            "1,help!,open,2,me,they,he|him,HIGH",
            "1,add trys,open,3,me,him,they|them,vscode,0.00,ynot,12",
            "1,test task,open,high,me,they,him|her,test project,12/25/2020"
        };
        static void Main(string[] args)
        {
            logger.Info("Program started");
            
            //display program title
            Ui.DisplayMenu("title");
            
            //read all the files and dump tickets into TicketList Class
            //create file if readfile returns null (no/empty file)
            TicketList.bugs = FileReader.ReadFile("bugs");
            if(TicketList.bugs != null) {
                logger.Info(TicketList.bugs.Count+" bug tickets added! next id = " + TicketList.getNextTicketID("bugs"));
            } else {
                CreateFile("bugs");
                TicketList.bugs = FileReader.ReadFile("bugs");
                logger.Info(TicketList.bugs.Count+" bug tickets added! next id = " + TicketList.getNextTicketID("bugs"));
            }
            
            TicketList.enhancements = FileReader.ReadFile("enhancements");
            if(TicketList.enhancements != null) {
                logger.Info(TicketList.enhancements.Count+" enhancement tickets added! next id = " + TicketList.getNextTicketID("enhancements"));
            } else {
                CreateFile("enhancements");
                TicketList.enhancements = FileReader.ReadFile("enhancements");
                logger.Info(TicketList.enhancements.Count+" enhancement tickets added! next id = " + TicketList.getNextTicketID("enhancements"));
            }

            TicketList.tasks = FileReader.ReadFile("tasks");
            if(TicketList.tasks != null) {
                logger.Info(TicketList.tasks.Count+" task tickets added! next id = " + TicketList.getNextTicketID("tasks"));
            } else {
                CreateFile("tasks");
                TicketList.tasks = FileReader.ReadFile("tasks");
                logger.Info(TicketList.tasks.Count+" task tickets added! next id = " + TicketList.getNextTicketID("tasks"));
            }
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
                    case "3" :
                        SearchTickets(); //loops until back to main menu is selected
                        break;
                    default : break;
                }
            }
            logger.Info("Program exit");
        }
        //display tickets in TicketList, which tickets based on user input
        private static void DisplayTickets() {
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
        private static void CreateTickets() {            
            string menuInput = "";
            while (menuInput != "0") {
                Ui.DisplayMenu("create");
                menuInput = Console.ReadLine();
                switch (menuInput) {
                    case "1" : //create bug
                        Bug b = (Bug) CreateTicket("bug");
                        logger.Info($"Bug ticket[{b.TicketID}] created!");
                        TicketList.bugs.Add(b);
                        FileWriter.WriteToFile(b.GetFileLineString(),"bugs");
                        break;
                    case "2" : //create enhancement
                        Enhancement e = (Enhancement) CreateTicket("enhancement");
                        logger.Info($"Enhancement ticket[{e.TicketID}] created!");
                        TicketList.enhancements.Add(e);
                        FileWriter.WriteToFile(e.GetFileLineString(),"enhancements");
                        break;
                    case "3" : //create task
                        Task t = (Task) CreateTicket("task");
                        logger.Info($"Task ticket[{t.TicketID}] created!");
                        TicketList.tasks.Add(t);
                        FileWriter.WriteToFile(t.GetFileLineString(),"tasks");
                        break;
                    default : break;
                }
            }
        }
        //Switch what type of ticket to create, get user input, return new ticket obj
        private static Ticket CreateTicket(string type) {
            string[] ticketProps;
            switch (type) {
                case "bug" : 
                    ticketProps = GetTicketData(new string[]{"","Summary","Status","Priority","Submitter","Assigned","Watching","Severity"},"bugs");
                    return new Bug(ticketProps[0],ticketProps[1],ticketProps[2],ticketProps[3],ticketProps[4],ticketProps[5],ticketProps[6],ticketProps[7]);
                case "enhancement" :
                    ticketProps = GetTicketData(new string[]{"","Summary","Status","Priority","Submitter","Assigned","Watching","Software", "Cost", "Reason", "Estimate"},"enhancements");
                    return new Enhancement(ticketProps[0],ticketProps[1],ticketProps[2],ticketProps[3],ticketProps[4],ticketProps[5],ticketProps[6],ticketProps[7],ticketProps[8],ticketProps[9],ticketProps[10]);
                case "task" :
                    ticketProps = GetTicketData(new string[]{"","Summary","Status","Priority","Submitter","Assigned","Watching","ProjectName","DueDate"},"tasks");
                    return new Task(ticketProps[0],ticketProps[1],ticketProps[2],ticketProps[3],ticketProps[4],ticketProps[5],ticketProps[6],ticketProps[7],ticketProps[8]);
                default : return null;
            }
        }
        //loop through passed in ticket properties and get user input,
        private static string[] GetTicketData(string[] props,string type) {
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
        //creates .csv file based on type arg
        private static void CreateFile(string type) {
            string lineData = (type == "bugs") ? Program._defaultFileData[0] : (type == "enhancements") ? Program._defaultFileData[1] : (type == "tasks") ? Program._defaultFileData[2] : null;
            FileWriter.WriteToFile(lineData,type);
        }
        private static void SearchTickets() {
            string menuInput ="";
            List<Ticket> foundList = new List<Ticket>();
            while (menuInput != "0") {
                Ui.DisplayMenu("search");
                menuInput = Console.ReadLine();
                string searchString = "";
                switch(menuInput) {
                    case "1":
                        Ui.GetDetailPrompt("status");
                        searchString = Console.ReadLine();
                        foundList = TicketList.FindTickets(searchString,"status");
                        break;
                    case "2":
                        Ui.GetDetailPrompt("priority");
                        searchString = Console.ReadLine();
                        foundList = TicketList.FindTickets(searchString,"priority");
                        break;
                    case "3":
                        Ui.GetDetailPrompt("submitter");
                        searchString = Console.ReadLine();
                        foundList = TicketList.FindTickets(searchString,"submitter");
                        break;
                    default : break;
                }
            }
        }
    }
}
