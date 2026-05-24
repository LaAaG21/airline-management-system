namespace aireline_system.Models
{
    internal struct Flight
    {
        public string FlightNo;
        public string IcaoCode;
        public string RegistrationNo;
        public string OriginIata;
        public string DestinationIata;
        public string GateCode;
        public DateTime ScheduledDeparture;
        public DateTime ScheduledArrival;
        public DateTime ActualDeparture;
        public DateTime ActualArrival;
        public string RouteType;
        public string Status;
        public int AvailableBusiness;
        public int AvailableEconomy;
        public decimal BasePrice;
        public int CreatedBy;
        public int UpdatedBy;
        public DateTime UpdatedAt;
    }
}