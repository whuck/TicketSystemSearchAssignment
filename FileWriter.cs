using System.IO;
namespace DotNetDbMidterm
{
    static class FileWriter
    {
        private const string bugsFile = "Tickets.csv";
        private const string enhancementsFile = "Enhancements.csv";
        private const string tasksFile ="Tasks.csv";

        public static void WriteToFile(string ticketLine, string type) {
            string file = (type == "bug") ? bugsFile : (type == "enhancement") ? enhancementsFile : (type == "task") ? tasksFile : null;
            if (System.IO.File.Exists(file)) {
                StreamWriter sw = new StreamWriter(file, append: true);
                sw.WriteLine(ticketLine);
                sw.Close();
            } else {
                //exception
            }
        }
         //ripped from Program.Main()

                        // else { //create file
                    //     Console.WriteLine("Ticket file not found, creating /Tickets.csv");
                    //     StreamWriter sw = new StreamWriter(file);
                    //     sw.WriteLine("0,Summary,Status,Priority,Submitter,Assigned,Watching1|Watching2");
                    //     sw.Close();
    //            string file = "Tickets.csv";
                //         else if(menuInput =="2"){
                //     //ask for each ticket field then smush em together and write to file
                //     if(System.IO.File.Exists(file)) {
                //         StreamWriter sw = new StreamWriter(file, append: true);
                //         string input = "";
                //         Console.WriteLine("Ticket ID:");
                //         input += Console.ReadLine();
                //         Console.WriteLine("Summary:");
                //         input += ',' + Console.ReadLine();
                //         Console.WriteLine("Status:");
                //         input += ',' + Console.ReadLine();
                //         Console.WriteLine("Priority:");
                //         input += ',' + Console.ReadLine();
                //         Console.WriteLine("Submitter:");
                //         input += ',' + Console.ReadLine();
                //         Console.WriteLine("Assigned:");
                //         input += ',' + Console.ReadLine();
                //         Console.WriteLine("Watching:");
                //         input += ',' + Console.ReadLine();
                //         sw.WriteLine(input);
                //         sw.Close();
                //     }
                // }   
    }
}