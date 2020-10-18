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
                        Bug b = (Bug) CreateTicket("bug");
                        //TicketList.bugs.Add(CreateTicket("bug"));
                        TicketList.bugs.Add(b);
                        FileWriter.WriteToFile(b.GetFileLineString(),"bug");
                        break;
                    case "2" : //create enhancement
                        Enhancement e = (Enhancement) CreateTicket("enhancement");
                        //TicketList.enhancements.Add(CreateTicket("enhancement"));
                        TicketList.enhancements.Add(e);
                        FileWriter.WriteToFile(e.GetFileLineString(),"enhancement");
                        //CreateTicket("enhancement");
                        break;
                    case "3" : //create task
                        Task t = (Task) CreateTicket("task");
                        TicketList.tasks.Add(t);
                        FileWriter.WriteToFile(t.GetFileLineString(),"task");
                        //TicketList.tasks.Add(CreateTicket("task"));
                        //CreateTicket("task");
                        break;
                }//switch
            }//while
        }//CreateTickets()
            //         switch (arg) {
            //     case "bugs" :
            //         //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
            //         return new Bug(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7]);
            //     case "enhancements" :
            //         //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching1|Watching2, Software, Cost, Reason, Estimate
            //         return new Enhancement(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7],lineItems[8],lineItems[9],lineItems[10]);
            //     case "tasks" :
            //         //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching1|Watching2, ProjectName, DueDate
            //         return new Task(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7],lineItems[8]);
            //     default : return null;
            // }
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
        static string[] GetTicketData(string[] props,string type) {
            string[] output = new string[props.Length];
            // foreach(var p in props) {
            //     Ui.GetDetailPrompt(p);
            // }
            // int nextID = (type == "bugs") ? TicketList.getNextTicketID("bugs") : 
            //     (type == "enhancements") ? TicketList.getNextTicketID("bugs") : 
            //     (type == "tasks") ? TicketList.getNextTicketID("bugs") : 0;
            int nextID = TicketList.getNextTicketID(type);
            //string fileName = (arg == "bugs") ? bugsFile : (arg == "enhancements") ? enhancementsFile : (arg == "tasks") ? tasksFile : null;
            output[0] = nextID.ToString();
            for(int i = 1; i < props.Length; i++) {
                Ui.GetDetailPrompt(props[i]);
                output[i] = Console.ReadLine();
            }
            return output;
        }
    }//class
}//namespace
