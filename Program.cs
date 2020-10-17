using System;
using System.IO;

namespace DotNetDbMidterm
{
    class Program
    {
        static void Main(string[] args)
        {

            //Main Menu / Screen
            string menuInput = "";
            string file = "Tickets.csv";
            Console.WriteLine("Welcome to TicketFest!");

            //loop menu options until quit is selected
            while (menuInput != "0") {
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("[1]Display Tickets");
                Console.WriteLine("[2]Create Ticket");
                Console.WriteLine("[0]Quit");
                //grab input
                menuInput = Console.ReadLine();

                //Display tickets... ie read file and display data
                if(menuInput == "1") {
                    //look for file if its not there create it
                    if(System.IO.File.Exists(file)) {
                        StreamReader sr = new StreamReader(file);
                        Console.WriteLine($"___________________________{file}____________________________________________________________");
                        //grab file data line by line and display it
                        while(!sr.EndOfStream) {
                            string line = sr.ReadLine();
                            Console.WriteLine(line);
                        }
                        sr.Close();
                        Console.WriteLine("__________________________________________________________________________________________");
                    }
                    else { //create file
                        Console.WriteLine("Ticket file not found, creating /Tickets.csv");
                        StreamWriter sw = new StreamWriter(file);
                        sw.WriteLine("0,Summary,Status,Priority,Submitter,Assigned,Watching1|Watching2");
                        sw.Close();

                    }
                }
                //create ticket line in file
                else if(menuInput =="2"){
                    //ask for each ticket field then smush em together and write to file
                    if(System.IO.File.Exists(file)) {
                        StreamWriter sw = new StreamWriter(file, append: true);
                        string input = "";
                        Console.WriteLine("Ticket ID:");
                        input += Console.ReadLine();
                        Console.WriteLine("Summary:");
                        input += ',' + Console.ReadLine();
                        Console.WriteLine("Status:");
                        input += ',' + Console.ReadLine();
                        Console.WriteLine("Priority:");
                        input += ',' + Console.ReadLine();
                        Console.WriteLine("Submitter:");
                        input += ',' + Console.ReadLine();
                        Console.WriteLine("Assigned:");
                        input += ',' + Console.ReadLine();
                        Console.WriteLine("Watching:");
                        input += ',' + Console.ReadLine();
                        sw.WriteLine(input);
                        sw.Close();
                    }
                }                
            }
        }
    }
}
