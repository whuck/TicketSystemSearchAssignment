using System;
namespace DotNetDbMidterm
{
    class Bug : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //Severity
        private string Severity{get;set;}
        public Bug(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string severity) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.Severity = severity;
        }
        public override string ToString()
        {
            return $"{base.ToString()}{this.Severity,9}";
        }
        // public override string[] GetProps() {
        //     string[] baseProps = base.GetProps();
        //     string[] bugProps = {"Severity"};
        //     string[] output = new string[baseProps.Length + bugProps.Length];
        //     baseProps.CopyTo(output,0);
        //     bugProps.CopyTo(output,baseProps.Length);
        //     return output;
        // }
        public override string GetFileLineString() {
            return base.GetFileLineString()+$",{this.Severity}";
        }
    }
    
}