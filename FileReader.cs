using System;
using System.IO;
using System.Collections;
using NLog.Web;
namespace DotNetDbMidterm
{
    static class FileReader
    {
        private const string bugsFile = "Tickets.csv";
        private const string enhancementsFile = "Enhancements.csv";
        private const string tasksFile ="Tasks.csv";
        
        public static ArrayList ReadAllFiles() {
            var output = new ArrayList();
            output.Add(ReadFile("bugs"));
            output.Add(ReadFile("enhancements"));
            output.Add(ReadFile("tasks"));
            return output;
        }
        public static ArrayList ReadFile(string arg) {
            // create instance of Logger
            string path = Directory.GetCurrentDirectory() + "\\nlog.config";
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();
            

            var output = new ArrayList();
            string fileName = (arg == "bugs") ? bugsFile : (arg == "enhancements") ? enhancementsFile : (arg == "tasks") ? tasksFile : null;
            //add try catch... or put in Program.cs?
            logger.Info($"Reading {fileName} started!");
            if(System.IO.File.Exists(fileName)) {
                StreamReader sr = new StreamReader(fileName);
                while(!sr.EndOfStream) {
                    string line = sr.ReadLine();
                    logger.Info($"{line} added to output");
                    output.Add(line);
                }
                sr.Close();
            } else {
                //file does not exist
            }
            return output;
        }
    }//class
}