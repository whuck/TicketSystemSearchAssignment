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

        public Ticket(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching) {
            this.TicketID = System.Int32.Parse(ticketID);
            this.Summary = summary;
            this.Status = status;
            this.Priority = priority;
            this.Submitter = submitter;
            this.Assigned = assigned;
            this.Watching = watching;
        }
        public override string ToString() {
            return $"{this.TicketID,8}{this.Summary,10}{this.Status,7}{this.Priority,9}{this.Submitter,10}{this.Assigned,9}{this.Watching,20}";
            //return TicketID + Summary + Status + Priority + Submitter       + Assigned + Watching;
        }
    }
}