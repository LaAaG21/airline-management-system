using aireline_system.Models;

namespace aireline_system.Helpers
{
    internal class CsvHelper
    {

        // ===================================================================================
        // FLIGHTS (VIEW , ADD , UPDATE , DELETE)
        // ===================================================================================

        public static List<Flight> ReadFlights()
        {
            List<Flight> flights = new List<Flight>();

            string[] lines = File.ReadAllLines(Program.FlightsFile);

            foreach (string line in lines)
            {
                if (line.Trim() == "")
                {
                    continue;
                }

                string[] data = line.Split(',');

                Flight flight = new Flight();

                if (data.Length > 0)
                {
                    flight.FlightNo = data[0];
                }
                if (data.Length > 1)
                {
                    flight.IcaoCode = data[1];
                }
                if (data.Length > 2)
                {
                    flight.RegistrationNo = data[2];
                }
                if (data.Length > 3)
                {
                    flight.OriginIata = data[3];
                }
                if (data.Length > 4)
                {
                    flight.DestinationIata = data[4];
                }
                if (data.Length > 5)
                {
                    flight.GateCode = data[5];
                }
                if (data.Length > 6 && data[6] != "")
                {
                    flight.ScheduledDeparture = DateTime.Parse(data[6]);
                }
                if (data.Length > 7)
                {
                    flight.ScheduledArrival = DateTime.Parse(data[7]);
                }
                if (data.Length > 8)
                {
                    flight.ActualDeparture = DateTime.Parse(data[8]);
                }
                if (data.Length > 9)
                {
                    flight.ActualArrival = DateTime.Parse(data[9]);
                }
                if (data.Length > 10)
                {
                    flight.RouteType = data[10];
                }
                if (data.Length > 11)
                {
                    flight.Status = data[11];
                }
                if (data.Length > 12)
                {
                    flight.AvailableBusiness = int.Parse(data[12]);
                }
                if (data.Length > 13)
                {
                    flight.AvailableEconomy = int.Parse(data[13]);
                }
                if (data.Length > 14)
                {
                    flight.BasePrice = decimal.Parse(data[14]);
                }
                if (data.Length > 15)
                {
                    flight.CreatedBy = int.Parse(data[15]);
                }
                if (data.Length > 16)
                {
                    flight.UpdatedBy = int.Parse(data[16]);
                }
                if (data.Length > 17)
                {
                    flight.UpdatedAt = DateTime.Parse(data[17]);
                }

                flights.Add(flight);
            }
            return flights;
        }

        public static void AddFlight(Flight flight)
        {
            string line =
                flight.FlightNo + "," +
                flight.IcaoCode + "," +
                flight.RegistrationNo + "," +
                flight.OriginIata + "," +
                flight.DestinationIata + "," +
                flight.GateCode + "," +
                flight.ScheduledDeparture + "," +
                flight.ScheduledArrival + "," +
                flight.ActualDeparture + "," +
                flight.ActualArrival + "," +
                flight.RouteType + "," +
                flight.Status + "," +
                flight.AvailableBusiness + "," +
                flight.AvailableEconomy + "," +
                flight.BasePrice + "," +
                flight.CreatedBy + "," +
                flight.UpdatedBy + "," +
                flight.UpdatedAt;

            File.AppendAllText(
                Program.FlightsFile,
                line + Environment.NewLine
            );
        }

        public static void UpdateFlight(string flightNo,Flight updatedFlight)
        {
            List<string> updatedLines = new List<string>();

            string[] lines = File.ReadAllLines(Program.FlightsFile);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (data[0] == flightNo)
                {
                    string updatedLine =
                        updatedFlight.FlightNo + "," +
                        updatedFlight.IcaoCode + "," +
                        updatedFlight.RegistrationNo + "," +
                        updatedFlight.OriginIata + "," +
                        updatedFlight.DestinationIata + "," +
                        updatedFlight.GateCode + "," +
                        updatedFlight.ScheduledDeparture + "," +
                        updatedFlight.ScheduledArrival + "," +
                        updatedFlight.ActualDeparture + "," +
                        updatedFlight.ActualArrival + "," +
                        updatedFlight.RouteType + "," +
                        updatedFlight.Status + "," +
                        updatedFlight.AvailableBusiness + "," +
                        updatedFlight.AvailableEconomy + "," +
                        updatedFlight.BasePrice + "," +
                        updatedFlight.CreatedBy + "," +
                        updatedFlight.UpdatedBy + "," +
                        updatedFlight.UpdatedAt;

                    updatedLines.Add(updatedLine);
                }
                else
                {
                    updatedLines.Add(line);
                }
            }

            File.WriteAllLines(
                Program.FlightsFile,
                updatedLines
            );
        }

        public static void DeleteFlight(string flightNo)
        {
            // =========================
            // CHECK TICKETS
            // =========================

            string[] ticketLines = File.ReadAllLines(Program.TicketsFile);

            foreach (string line in ticketLines)
            {
                string[] data = line.Split(',');

                // ticket flight_no
                if (data[1] == flightNo)
                {
                    Console.WriteLine("Cannot delete flight because tickets are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK FLIGHT DELAYS
            // =========================

            string[] delayLines = File.ReadAllLines(Program.FlightDelaysFile);

            foreach (string line in delayLines)
            {
                string[] data = line.Split(',');

                // delay flight_no
                if (data[1] == flightNo)
                {
                    Console.WriteLine("Cannot delete flight because delay records are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK CREW ASSIGNMENTS
            // =========================

            string[] assignmentLines = File.ReadAllLines(Program.FlightCrewAssignmentsFile);

            foreach (string line in assignmentLines)
            {
                string[] data = line.Split(',');

                // assignment flight_no
                if (data[1] == flightNo)
                {
                    Console.WriteLine("Cannot delete flight because crew assignments are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK MAINTENANCE LOGS
            // =========================

            string[] maintenanceLines = File.ReadAllLines(Program.MaintenanceLogsFile);

            foreach (string line in maintenanceLines)
            {
                string[] data = line.Split(',');

                // maintenance flight_no
                if (data[2] == flightNo)
                {
                    Console.WriteLine("Cannot delete flight because maintenance logs are linked to it.");
                    return;
                }
            }

            // =========================
            // DELETE FLIGHT
            // =========================

            List<string> updatedLines = new List<string>();

            string[] flightLines = File.ReadAllLines(Program.FlightsFile);

            foreach (string line in flightLines)
            {
                string[] data = line.Split(',');

                // keep all other flights
                if (data[0] != flightNo)
                {
                    updatedLines.Add(line);
                }
            }

            File.WriteAllLines(Program.FlightsFile,updatedLines);

            Console.WriteLine("Flight deleted successfully.");
        }



        // ===================================================================================
        // ADMINS (VIEW , ADD , UPDATE , DELETE)
        // ===================================================================================

        public static List<Admin> ReadAdmins()
        {
            List<Admin> admins = new List<Admin>();

            string[] lines = File.ReadAllLines(Program.AdminsFile);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (data.Length >= 11)
                {
                    Admin admin = new Admin();
                    admin.AdminId = int.Parse(data[0]);
                    admin.Username = data[1];
                    admin.FullName = data[2];
                    admin.Email = data[3];
                    admin.PasswordHash = data[4];
                    admin.Role = data[5];
                    admin.IsActive = bool.Parse(data[6]);
                    admin.FailedAttempts = int.Parse(data[7]);
                    admin.LockedUntil = DateTime.Parse(data[8]);
                    admin.LastLogin = DateTime.Parse(data[9]);
                    admin.CreatedAt = DateTime.Parse(data[10]);
                    admins.Add(admin);
                }
            }
            return admins;
        }

        public static void AddAdmin(Admin admin)
        {
            string line =
                admin.AdminId + "," +
                admin.Username + "," +
                admin.FullName + "," +
                admin.Email + "," +
                admin.PasswordHash + "," +
                admin.Role + "," +
                admin.IsActive + "," +
                admin.FailedAttempts + "," +
                admin.LockedUntil + "," +
                admin.LastLogin + "," +
                admin.CreatedAt;

            File.AppendAllText(Program.AdminsFile,line + Environment.NewLine);
        }

        public static void UpdateAdmin(int adminId,Admin updatedAdmin)
        {
            List<string> updatedLines = new List<string>();

            string[] lines = File.ReadAllLines(Program.AdminsFile);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[0]) == adminId)
                {
                    string updatedLine =
                        updatedAdmin.AdminId + "," +
                        updatedAdmin.Username + "," +
                        updatedAdmin.FullName + "," +
                        updatedAdmin.Email + "," +
                        updatedAdmin.PasswordHash + "," +
                        updatedAdmin.Role + "," +
                        updatedAdmin.IsActive + "," +
                        updatedAdmin.FailedAttempts + "," +
                        updatedAdmin.LockedUntil + "," +
                        updatedAdmin.LastLogin + "," +
                        updatedAdmin.CreatedAt;

                    updatedLines.Add(updatedLine);
                }
                else
                {
                    updatedLines.Add(line);
                }
            }

            File.WriteAllLines(Program.AdminsFile,updatedLines);
        }

        public static void DeleteAdmin(int adminId)
        {
            // =========================
            // CHECK AIRPORTS
            // =========================

            string[] airportLines = File.ReadAllLines(Program.AirportsFile);

            foreach (string line in airportLines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[5]) == adminId)
                {
                    Console.WriteLine("Cannot delete admin because airports are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK AIRLINES
            // =========================

            string[] airlineLines = File.ReadAllLines(Program.AirlinesFile);

            foreach (string line in airlineLines)
            {
                string[] data =line.Split(',');

                if (int.Parse(data[7]) == adminId)
                {
                    Console.WriteLine("Cannot delete admin because airlines are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK FLIGHTS
            // =========================

            string[] flightLines = File.ReadAllLines(Program.FlightsFile);

            foreach (string line in flightLines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[15]) == adminId || int.Parse(data[16]) == adminId)
                {
                    Console.WriteLine("Cannot delete admin because flights are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK CREW MEMBERS
            // =========================

            string[] crewLines = File.ReadAllLines(Program.CrewMembersFile);

            foreach (string line in crewLines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[10]) == adminId)
                {
                    Console.WriteLine("Cannot delete admin because crew members are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK PROMOTIONS
            // =========================

            string[] promotionLines = File.ReadAllLines(Program.PromotionsFile);

            foreach (string line in promotionLines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[8]) == adminId)
                {
                    Console.WriteLine("Cannot delete admin because promotions are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK SYSTEM LOGS
            // =========================

            string[] logLines = File.ReadAllLines(Program.LogsFile);

            foreach (string line in logLines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[1]) == adminId)
                {
                    Console.WriteLine("Cannot delete admin because logs are linked to it.");
                    return;
                }
            }

            // =========================
            // DELETE ADMIN
            // =========================

            List<string> updatedLines = new List<string>();

            string[] adminLines = File.ReadAllLines(Program.AdminsFile);

            foreach (string line in adminLines)
            {
                string[] data = line.Split(',');

                if (int.Parse(data[0]) != adminId)
                {
                    updatedLines.Add(line);
                }
            }

            File.WriteAllLines(Program.AdminsFile,updatedLines);

            Console.WriteLine("Admin deleted successfully.");
        }



        // ===================================================================================
        // AIRCRAFT (VIEW , ADD , UPDATE , DELETE)
        // ===================================================================================

        public static List<Aircraft> ReadAircrafts()
        {
            List<Aircraft> aircrafts = new List<Aircraft>();

            string[] lines = File.ReadAllLines(Program.AircraftFile);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (data.Length >= 12)
                {
                    Aircraft aircraft = new Aircraft();
                    aircraft.RegistrationNo = data[0];
                    aircraft.IcaoCode = data[1];
                    aircraft.Model = data[2];
                    aircraft.Manufacturer = data[3];
                    aircraft.YearManufactured = int.Parse(data[4]);
                    aircraft.TotalSeats = int.Parse(data[5]);
                    aircraft.BusinessSeats = int.Parse(data[6]);
                    aircraft.EconomySeats = int.Parse(data[7]);
                    aircraft.Status = data[8];
                    aircraft.FlightsOperated = int.Parse(data[9]);
                    aircraft.CreatedBy = int.Parse(data[10]);
                    aircraft.UpdatedAt = DateTime.Parse(data[11]);
                    aircrafts.Add(aircraft);
                }
            }

            return aircrafts;
        }

        public static void AddAircraft(Aircraft aircraft)
        {
            string line =
                aircraft.RegistrationNo + "," +
                aircraft.IcaoCode + "," +
                aircraft.Model + "," +
                aircraft.Manufacturer + "," +
                aircraft.YearManufactured + "," +
                aircraft.TotalSeats + "," +
                aircraft.BusinessSeats + "," +
                aircraft.EconomySeats + "," +
                aircraft.Status + "," +
                aircraft.FlightsOperated + "," +
                aircraft.CreatedBy + "," +
                aircraft.UpdatedAt;

            File.AppendAllText(Program.AircraftFile,line + Environment.NewLine);
        }

        public static void UpdateAircraft(string registrationNo,Aircraft updatedAircraft)
        {
            List<string> updatedLines = new List<string>();

            string[] lines = File.ReadAllLines(Program.AircraftFile);

            foreach (string line in lines)
            {
                string[] data = line.Split(',');

                if (data[0] == registrationNo)
                {
                    string updatedLine =
                        updatedAircraft.RegistrationNo + "," +
                        updatedAircraft.IcaoCode + "," +
                        updatedAircraft.Model + "," +
                        updatedAircraft.Manufacturer + "," +
                        updatedAircraft.YearManufactured + "," +
                        updatedAircraft.TotalSeats + "," +
                        updatedAircraft.BusinessSeats + "," +
                        updatedAircraft.EconomySeats + "," +
                        updatedAircraft.Status + "," +
                        updatedAircraft.FlightsOperated + "," +
                        updatedAircraft.CreatedBy + "," +
                        updatedAircraft.UpdatedAt;

                    updatedLines.Add(updatedLine);
                }
                else
                {
                    updatedLines.Add(line);
                }
            }

            File.WriteAllLines(Program.AircraftFile,updatedLines);
        }

        public static void DeleteAircraft(string registrationNo)
        {
            // =========================
            // CHECK FLIGHTS
            // =========================

            string[] flightLines = File.ReadAllLines(Program.FlightsFile);

            foreach (string line in flightLines)
            {
                string[] data = line.Split(',');

                if (data[2] == registrationNo)
                {
                    Console.WriteLine("Cannot delete aircraft because flights are linked to it.");
                    return;
                }
            }

            // =========================
            // CHECK MAINTENANCE LOGS
            // =========================

            string[] maintenanceLines = File.ReadAllLines(Program.MaintenanceLogsFile);

            foreach (string line in maintenanceLines)
            {
                string[] data = line.Split(',');

                if (data[1] == registrationNo)
                {
                    Console.WriteLine("Cannot delete aircraft because maintenance logs are linked to it.");
                    return;
                }
            }

            // =========================
            // DELETE AIRCRAFT
            // =========================

            List<string> updatedLines = new List<string>();

            string[] aircraftLines = File.ReadAllLines(Program.AircraftFile);

            foreach (string line in aircraftLines)
            {
                string[] data = line.Split(',');

                if (data[0] != registrationNo)
                {
                    updatedLines.Add(line);
                }
            }

            File.WriteAllLines(Program.AircraftFile,updatedLines);

            Console.WriteLine("Aircraft deleted successfully.");
        }
    }
}