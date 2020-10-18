namespace DotNetDbMidterm
{
    class Enhancement : Ticket
    { 
        //Enhancement Class, child of ticket with its own properties
        //overriden ToString for terminal output formatting
        //overriden GetFileLineString for easy file writing
        private string Software;
        private string Cost;
        private string Reason;
        private string Estimate;
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

        public override string GetFileLineString() {
            return base.GetFileLineString()+$",{this.Software},{this.Cost},{this.Reason},{this.Estimate}";
        }
        
    }
}