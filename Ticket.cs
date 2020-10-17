namespace DotNetDbMidterm
{
    class Ticket
    {
        //TicketID, Summary, Status, Priority, Submitter, Assigned, Watching
        private int TicketID {get;}
        private string Summary{get;}
        private string Status{get;}
        private string Priority{get;}
        private string Submitter{get;}
        private string Assigned{get;}
        private string Watching{get;}

        public Ticket(int ticketID, string summary, string status, string priority, string submitter, string assigned, string watching) {
            this.TicketID = ticketID;
            this.Summary = summary;
            this.Status = status;
            this.Priority = priority;
            this.Submitter = submitter;
            this.Assigned = assigned;
            this.Watching = watching;
        }
        public override string ToString() {
            return TicketID.ToString() + Summary + Status + Priority + Submitter 
            + Assigned + Watching;
        }
    }
}