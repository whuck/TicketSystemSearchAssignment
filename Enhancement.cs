namespace DotNetDbMidterm
{
    class Enhancement : Ticket
    { 
        //from Ticket --> TicketID, Summary, Status, Priority, Submitter, Assigned, Watching, 
        //Software, Cost, Reason, Estimate
        private string Software {get;}
        private string Cost {get;}
        private string Reason {get;}
        private string Estimate {get;}
        public Enhancement(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching,string software, string cost, string reason, string estimate) : base(ticketID, summary, status, priority, submitter, assigned, watching){
            this.Software = software;
            this.Cost = cost;
            this.Reason = reason;
            this.Estimate = estimate;
        }
        public override string ToString()
        {
            return $"{base.ToString()}{this.Software,9}{this.Cost,5}{this.Reason,7}{this.Estimate,9}";
        }
        // public override string[] GetProps() {
        //     string[] baseProps = base.GetProps();
        //     string[] enhProps = {"Software","Cost","Reason","Estimate"};
        //     string[] output = new string[baseProps.Length + enhProps.Length];
        //     baseProps.CopyTo(output,0);
        //     enhProps.CopyTo(output,baseProps.Length);
        //     return output;
        // }
        public override string GetFileLineString() {
            return base.GetFileLineString()+$",{this.Software},{this.Cost},{this.Reason},{this.Estimate}";
        }
        
    }
}