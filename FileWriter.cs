using System.IO;
namespace DotNetDbMidterm
{
    static class FileWriter
    {
        //FileWriter class writes ticket objects to files
        private const string bugsFile = "Tickets.csv";
        private const string enhancementsFile = "Enhancements.csv";
        private const string tasksFile ="Tasks.csv";

        public static void WriteToFile(string ticketLine, string type) {
            Program.logger.Info($"Writing {type}:{ticketLine} to file");
            //set file to write to based on type arg
            string file = (type == "bug") ? bugsFile : (type == "enhancement") ? enhancementsFile : (type == "task") ? tasksFile : null;
            if (System.IO.File.Exists(file)) {
                StreamWriter sw = new StreamWriter(file, append: true);
                sw.WriteLine(ticketLine);
                sw.Close();
                Program.logger.Info($"{type} wrote to file!");
            } else {
                //exception
                Program.logger.Error("WriteTo file does not exist!");
            }
        }
    }
}