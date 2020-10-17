namespace DotNetDbMidterm
{
    class Task : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //ProjectName, DueDate
        private string ProjectName{get;}
        private string DueDate{get;}
        public Task(int ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.ProjectName = projectName;
            this.DueDate = dueDate;
        }

        public override string ToString()
        {
            return base.ToString() + ProjectName + DueDate;
        }
    }
}