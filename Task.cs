namespace DotNetDbMidterm
{
    class Task : Ticket
    { 
        //Task Class, child of ticket with its own properties
        //overriden ToString for terminal output formatting
        //overriden GetFileLineString for easy file writing
        private string ProjectName;
        private string DueDate;
        public Task(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.ProjectName = projectName;
            this.DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.ProjectName,13}{this.DueDate,11}";
        }
        public override string GetFileLineString() {
            return base.GetFileLineString()+$",{this.ProjectName},{this.DueDate}";
        }
    }
}