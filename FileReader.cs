using System;
using System.IO;
using System.Collections.Generic;
namespace DotNetDbMidterm
{
    static class FileReader
    {
        //FileReader class reads ticket files, parses file lines, and creates ticket objects
        public static List<Ticket> ReadFile(string type) {
            List<Ticket> output = new List<Ticket>();
            // assign fileName based on passed argument string
            string fileName = (type == "bugs") ? Program._bugsFile : (type == "enhancements") ? Program._enhancementsFile : (type == "tasks") ? Program._tasksFile : null;
            //add try catch... or put in Program.cs?
            Program.logger.Info($"Reading {fileName} started!");
            if(System.IO.File.Exists(fileName)) {
                StreamReader sr = new StreamReader(fileName);
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    Program.logger.Info($"{line} added to output");
                    output.Add(ParseLine(line,type));
                }
                sr.Close();
            } else {
                //file does not exist
                Program.logger.Error($"ReadFile({fileName}) does not exist!");
                return null;
            }
            return output;
        }
        private static Ticket ParseLine(string line,string type) {
            //obviously commas in any fields of the csv will fork this up royaly
            string[] lineItems = line.Split(",");
            Program.logger.Info($"Begin Parsing {type} line:{line}");
            switch (type) {
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
    }
}