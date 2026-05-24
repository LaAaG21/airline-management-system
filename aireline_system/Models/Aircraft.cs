using System;
using System.Collections.Generic;
using System.Text;

namespace aireline_system.Models
{
    internal class Aircraft
    {
        public string RegistrationNo;

        public string IcaoCode;

        public string Model;

        public string Manufacturer;

        public int YearManufactured;

        public int TotalSeats;

        public int BusinessSeats;

        public int EconomySeats;

        public string Status;

        public int FlightsOperated;

        public int CreatedBy;

        public DateTime UpdatedAt;
    }
}
