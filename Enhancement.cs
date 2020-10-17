namespace DotNetDbMidterm
{
    class Enhancement : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //Software, Cost, Reason, Estimate
        private string Software{get;}
        private string Cost {get;}
        private string Reason {get;}
        private string Estimate {get;}

        public override string ToString()
        {
            return base.ToString() + Software + Cost + Reason + Estimate;
        }
    }
}