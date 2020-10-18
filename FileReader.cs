using System.IO;
using System.Collections.Generic;
namespace DotNetDbMidterm
{
    static class FileReader
    {
        //FileReader class reads ticket files, parses file lines, and creates ticket objects
        private const string bugsFile = "Tickets.csv";
        private const string enhancementsFile = "Enhancements.csv";
        private const string tasksFile ="Tasks.csv";
        public static List<List<Ticket>> ReadAllFiles() {
            Program.logger.Info("Begin read all files.");
            //make multi dimensional out put array and dump tickets in from file
            List<List<Ticket>> output = new List<List<Ticket>>();
            output.Add(ReadFile("bugs"));
            output.Add(ReadFile("enhancements"));
            output.Add(ReadFile("tasks"));
            return output;
        }
        public static List<Ticket> ReadFile(string arg) {
            List<Ticket> output = new List<Ticket>();
            // assign fileName based on passed argument string
            string fileName = (arg == "bugs") ? bugsFile : (arg == "enhancements") ? enhancementsFile : (arg == "tasks") ? tasksFile : null;
            //add try catch... or put in Program.cs?
            Program.logger.Info($"Reading {fileName} started!");
            if(System.IO.File.Exists(fileName)) {
                StreamReader sr = new StreamReader(fileName);
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    Program.logger.Info($"{line} added to output");
                    output.Add(ParseLine(line,arg));
                }
                sr.Close();
            } else {
                //file does not exist
                Program.logger.Error($"File{fileName} does not exist!");
            }
            return output;
        }
        private static Ticket ParseLine(string line,string arg) {
            //obviously commas in any fields of the csv will fork this up royaly
            string[] lineItems = line.Split(",");
            Program.logger.Info($"Begin Parsing {arg} type");
            switch (arg) {
                case "bugs" :
                    //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
                    return new Bug(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7]);
                case "enhancements" :
                    //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching1|Watching2, Software, Cost, Reason, Estimate
                    return new Enhancement(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7],lineItems[8],lineItems[9],lineItems[10]);
                case "tasks" :
                    //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching1|Watching2, ProjectName, DueDate
                    return new Task(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7],lineItems[8]);
                default : return null;
            }
        }
    }//class
}