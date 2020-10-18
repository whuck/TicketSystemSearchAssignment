using System;
namespace DotNetDbMidterm
{
    class Bug : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //Severity
        private string Severity{get;}
        public Bug(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string severity) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.Severity = severity;
        }
        public override string ToString()
        {
            return base.ToString() + Severity;
        }
    }
}