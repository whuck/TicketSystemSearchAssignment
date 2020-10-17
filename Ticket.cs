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

        public override string ToString() {
            return TicketID.ToString() + Summary + Status + Priority + Submitter 
            + Assigned + Watching;
        }
    }
}