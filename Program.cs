using System;
using System.IO;
using System.Collections;
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

            //display program title
            Ui.DisplayMenu("title");
            string menuInput = "";

            //loop Main Menu options until quit is selected
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
                ArrayList ticketList = new ArrayList();
                switch (menuInput) {
                    case "1" : //display all
                        ticketList = FileReader.ReadAllFiles();
                        Ui.DisplayTickets(ticketList,true);
                        break;
                    case "2" : //display bugs
                        ticketList = FileReader.ReadFile("bugs");
                        Ui.DisplayTickets(ticketList,false);
                        break;
                    case "3" : //display enhancement
                        ticketList = FileReader.ReadFile("enhancements");
                        Ui.DisplayTickets(ticketList, false);
                        break;
                    case "4" : //display task
                        ticketList = FileReader.ReadFile("tasks");
                        Ui.DisplayTickets(ticketList,false);
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
                        break;
                    case "2" : //create enhancement
                        break;
                    case "3" : //create task
                        break;
                }//switch
            }//while
        }//CreateTickets()
    }//class
}//namespace
