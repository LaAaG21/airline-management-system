using aireline_system.Models;
using aireline_system.Helpers;

namespace aireline_system
{
    internal class Program
    {

        public const string AdminsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\admins.csv";
        public const string PassengersFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\passengers.csv";
        public const string FlightsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\flights.csv";
        public const string TicketsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\tickets.csv";
        public const string PaymentsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\payments.csv";
        public const string AirportsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\airports.csv";
        public const string AirlinesFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\airlines.csv";
        public const string AircraftFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\aircrafts.csv";
        public const string PromotionsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\promotions.csv";
        public const string CrewMembersFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\crew_members.csv";
        public const string LogsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\system_logs.csv";
        public const string BaggageFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\baggage.csv";
        public const string DepartureGatesFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\departure_gates.csv";
        public const string FlightCrewAssignmentsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\flight_crew_assignments.csv";
        public const string FlightDelaysFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\flight_delays.csv";
        public const string LoyaltyPointsLogsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\loyalty_points_logs.csv";
        public const string MaintenanceLogsFile = "C:\\Users\\Codeline\\Desktop\\airline-management-system\\aireline_system\\Data\\maintenance_logs.csv";

        static void Main(string[] args)
        {
            ShowLandingMenu();
        }

        static void ShowLandingMenu()
        {
            string[] options =
            {
                "Login",
                "Register",
                "Exit"
            };

            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();

                DrawHeader();

                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;

                        Console.ForegroundColor = ConsoleColor.White;

                        Console.WriteLine(
                            $"> {options[i]}"
                        );
                    }
                    else
                    {
                        Console.ResetColor();

                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine(
                            $"  {options[i]}"
                        );
                    }
                }

                Console.ResetColor();

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex--;

                    if (selectedIndex < 0)
                    {
                        selectedIndex = options.Length - 1;
                    }
                }

                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex++;

                    if (selectedIndex >= options.Length)
                    {
                        selectedIndex = 0;
                    }
                }

            } while (key != ConsoleKey.Enter);

            Console.Clear();

            switch (selectedIndex)
            {
                case 0:

                    Console.WriteLine("Login Screen");
                    break;

                case 1:

                    Console.WriteLine("Register Screen");
                    break;

                case 2:

                    Environment.Exit(0);

                    break;
            }
        }

        static void DrawHeader()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("=========================================");

            Console.WriteLine("      AIRLINE MANAGEMENT SYSTEM");

            Console.WriteLine("=========================================");

            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("Use arrows and ENTER");
            Console.WriteLine();
        }
    }
}
