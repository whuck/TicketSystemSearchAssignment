using System.IO;
namespace DotNetDbMidterm
{
    static class FileWriter
    {
        //FileWriter class writes ticket objects to files
        public static void WriteToFile(string ticketLine, string type) {
            Program.logger.Info($"Writing {type}:{ticketLine} to file");
            //set file to write to based on type arg
            string file = (type == "bugs") ? Program._bugsFile : (type == "enhancements") ? Program._enhancementsFile : (type == "tasks") ? Program._tasksFile : null;
            if (System.IO.File.Exists(file)) {
                StreamWriter sw = new StreamWriter(file, append: true);
                sw.WriteLine(ticketLine);
                sw.Close();
                Program.logger.Info($"{type} wrote to file!");
            } else {
                //file doesn't exist. write w/o append arg
                StreamWriter sw = new StreamWriter(file);
                sw.WriteLine(ticketLine);
                sw.Close();
                Program.logger.Info($"{type} file created!");
            }
        }
    }
}