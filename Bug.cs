namespace DotNetDbMidterm
{
    class Bug : Ticket
    { 
        //Bug Class, child of ticket with its own properties
        //overriden ToString for terminal output formatting
        //overriden GetFileLineString for easy file writing
        private string Severity;
        public Bug(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string severity) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.Severity = severity;
        }
        public override string ToString()
        {
            return $"{base.ToString()}{this.Severity,9}";
        }

        public override string GetFileLineString() {
            return base.GetFileLineString()+$",{this.Severity}";
        }
    }
    
}