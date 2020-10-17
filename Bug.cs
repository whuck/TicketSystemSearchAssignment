namespace DotNetDbMidterm
{
    class Bug : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //Severity
        private string Severity{get;}
        public override string ToString()
        {
            return base.ToString() + Severity;
        }
    }
}