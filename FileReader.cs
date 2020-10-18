using System;
using System.IO;
using System.Collections.Generic;
using NLog.Web;
namespace DotNetDbMidterm
{
    static class FileReader
    {
        private const string bugsFile = "Tickets.csv";
        private const string enhancementsFile = "Enhancements.csv";
        private const string tasksFile ="Tasks.csv";
        
        public static List<List<Ticket>> ReadAllFiles() {
            List<List<Ticket>> output = new List<List<Ticket>>();
            output.Add(ReadFile("bugs"));
            output.Add(ReadFile("enhancements"));
            output.Add(ReadFile("tasks"));
            return output;
        }
        public static List<Ticket> ReadFile(string arg) {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            List<Ticket> output = new List<Ticket>();
            // assign fileName based on passed argument string
            string fileName = (arg == "bugs") ? bugsFile : (arg == "enhancements") ? enhancementsFile : (arg == "tasks") ? tasksFile : null;
            //add try catch... or put in Program.cs?
            logger.Info($"Reading {fileName} started!");
            if(System.IO.File.Exists(fileName)) {
                StreamReader sr = new StreamReader(fileName);
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    logger.Info($"{line} added to output");
                    output.Add(ParseLine(line,arg));
                }
                sr.Close();
            } else {
                //file does not exist
            }
            return output;
        }
        private static Ticket ParseLine(string line,string arg) {
            string[] lineItems = line.Split(",");
            // Console.WriteLine(line);
            // Console.WriteLine(arg);
            // Console.WriteLine(lineItems[0]);
            switch (arg) {
                case "bugs" :
                    return new Bug(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7]);
                case "enhancements" :
                    return new Enhancement(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7],lineItems[8],lineItems[9],lineItems[10]);
                case "tasks" :
                    return new Task(lineItems[0],lineItems[1],lineItems[2],lineItems[3],lineItems[4],lineItems[5],lineItems[6],lineItems[7],lineItems[8]);
                default : return null;
            }
        }
    }//class
}