namespace DotNetDbMidterm
{
    class Task : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //ProjectName, DueDate
        private string ProjectName{get;}
        private string DueDate{get;}
        public override string ToString()
        {
            return base.ToString() + ProjectName + DueDate;
        }
    }
}