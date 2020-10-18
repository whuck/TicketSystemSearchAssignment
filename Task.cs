namespace DotNetDbMidterm
{
    class Task : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //ProjectName, DueDate
        private string ProjectName {get;}
        private string DueDate {get;}
        public Task(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.ProjectName = projectName;
            this.DueDate = dueDate;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{this.ProjectName,13}{this.DueDate,11}";
        }
        // public override string[] GetProps() {
        //     string[] baseProps = base.GetProps();
        //     string[] taskProps = {"Project Name","Due Date"};
        //     string[] output = new string[baseProps.Length + taskProps.Length];
        //     baseProps.CopyTo(output,0);
        //     taskProps.CopyTo(output,baseProps.Length);
        //     return output;
        // }
        public override string GetFileLineString() {
            return base.GetFileLineString()+$",{this.ProjectName},{this.DueDate}";
        }
    }
}