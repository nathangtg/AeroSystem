using AeroSystem.models.Baggage;
using AeroSystem.models.BoardingPass;
using AeroSystem.models.Flight;
using AeroSystem.models.Group;
using AeroSystem.models.Passenger;
using AeroSystem.models.SelfServiceKiosk;
using AeroSystem.models.Staff;
using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    private static Random random = new Random();

    public static void Main(string[] args)
    {
        List<Flight> flights = new List<Flight>();
        List<Passenger> passengers = new List<Passenger>();
        List<Baggage> baggageList = new List<Baggage>();
        List<Staff> staffList = new List<Staff>();
        List<SelfServiceKiosk> kiosks = GenerateKiosks(1);

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Generate Flights");
            Console.WriteLine("2. Generate Passengers");
            Console.WriteLine("3. Generate Staff");
            Console.WriteLine("4. Select Flight and Perform Operations");
            Console.WriteLine("5. Print Kiosks");
            Console.WriteLine("6. Print Staff");
            Console.WriteLine("7. Print Passengers");
            Console.WriteLine("8. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        flights = GenerateFlights(GetPositiveIntegerInput("Enter number of flights to generate: "));
                        break;
                    case 2:
                        if (flights.Count == 0)
                        {
                            Console.WriteLine("No flights available. Please generate flights first.");
                        }
                        else
                        {
                            passengers = GeneratePassengers(GetPositiveIntegerInput("Enter number of passengers to generate: "), flights);
                            baggageList = GenerateBaggage(passengers.Count, passengers);
                        }
                        break;
                    case 3:
                        staffList = GenerateStaff(GetPositiveIntegerInput("Enter number of staff to generate: "));
                        break;
                    case 4:
                        if (flights.Count == 0)
                        {
                            Console.WriteLine("No flights available. Please generate flights first.");
                        }
                        else if (passengers.Count == 0)
                        {
                            Console.WriteLine("No passengers available. Please generate passengers first.");
                        }
                        else
                        {
                            PerformFlightOperations(kiosks[0], flights, passengers, baggageList);
                        }
                        break;
                    case 5:
                        PrintKiosks(kiosks);
                        break;
                    case 6:
                        PrintStaff(staffList);
                        break;
                    case 7:
                        PrintPassengers(passengers);
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }

    private static int GetPositiveIntegerInput(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out result) && result > 0)
            {
                return result;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }
    }

    private static void PerformFlightOperations(SelfServiceKiosk kiosk, List<Flight> flights, List<Passenger> passengers, List<Baggage> baggageList)
    {
        Console.WriteLine("Select a flight:");
        PrintFlights(flights);

        Flight? selectedFlight = null;

        while (selectedFlight == null)
        {
            selectedFlight = GetSelectedFlight(flights);
            if (selectedFlight == null)
            {
                Console.WriteLine("Flight not found. Please enter a valid flight number.");
            }

            if (selectedFlight != null)
            {
                Console.WriteLine($"Selected Flight: {selectedFlight.FlightNumber} from {selectedFlight.Origin} to {selectedFlight.Destination}");

                while (true)
                {
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Check-in Passengers");
                    Console.WriteLine("2. Print Boarding Passes");
                    Console.WriteLine("3. Print Baggage Information");
                    Console.WriteLine("4. Back to Main Menu");
                    Console.Write("Enter option number: ");

                    if (int.TryParse(Console.ReadLine(), out int option))
                    {
                        switch (option)
                        {
                            case 1:
                                CheckInPassengers(kiosk, passengers, selectedFlight);
                                break;
                            case 2:
                                PrintBoardingPasses(kiosk, passengers, selectedFlight);
                                break;
                            case 3:
                                PrintBaggageInformation(baggageList, selectedFlight);
                                break;
                            case 4:
                                return;
                            default:
                                Console.WriteLine("Invalid option. Please enter a number between 1 and 4.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a number.");
                    }

                    Console.WriteLine("--------------");
                }
            }
        }
    }

    private static Flight? GetSelectedFlight(List<Flight> flights)
    {
        Console.Write("Enter flight number: ");
        string? flightNumber = Console.ReadLine();
        if (flightNumber != null)
        {
            return flights.FirstOrDefault(f => f.FlightNumber == flightNumber);
        }
        return null;
    }

    private static void CheckInPassengers(SelfServiceKiosk kiosk, List<Passenger> passengers, Flight flight)
    {
        foreach (Passenger p in passengers.Where(p => p.Flight.FlightNumber == flight.FlightNumber))
        {
            kiosk.selfCheckIn(p, p.Flight);
        }
    }

    private static void PrintBoardingPasses(SelfServiceKiosk kiosk, List<Passenger> passengers, Flight flight)
    {
        foreach (Passenger p in passengers.Where(p => p.Flight.FlightNumber == flight.FlightNumber))
        {
            BoardingPass boardingPass = new BoardingPass(flight, "B2", DateTime.Now, DateTime.Now.AddHours(3), p);
            kiosk.printBoardingPass(p, flight, boardingPass);
        }
    }

    private static void PrintBaggageInformation(List<Baggage> baggageList, Flight flight)
    {
        foreach (Baggage b in baggageList.Where(b => b.Flight.FlightNumber == flight.FlightNumber))
        {
            Console.WriteLine($"Baggage ID: {b.BaggageId}, Weight: {b.Weight}, Owner: {b.Owner.FullName}, Flight: {b.Flight.FlightNumber}, Screening Status: {b.ScreeningStatus}");
        }
        Console.WriteLine("--------------");
    }

    private static void PrintKiosks(List<SelfServiceKiosk> kiosks)
    {
        foreach (var kiosk in kiosks)
        {
            Console.WriteLine($"Kiosk ID: {kiosk.KioskId}");
        }
    }

    private static void PrintStaff(List<Staff> staffList)
    {
        foreach (var staff in staffList)
        {
            Console.WriteLine($"Staff ID: {staff.StaffId}, Name: {staff.FirstName} {staff.LastName}, Position: {staff.Position}");
        }
    }

    private static void PrintPassengers(List<Passenger> passengers)
    {
        foreach (var passenger in passengers)
        {
            Console.WriteLine($"Passenger: {passenger.FullName}, Passport Number: {passenger.PassportNumber}, Flight: {passenger.Flight.FlightNumber}, Special Needs: {passenger.SpecialNeedsDetails}");
        }
    }

    private static string GetRandomName()
    {
        string[] names = { "John", "Emily", "Michael", "Sophia", "William", "Emma", "David", "Olivia", "James", "Ava" };
        return names[random.Next(names.Length)];
    }

    private static string GeneratePassportNumber()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        return new string(Enumerable.Repeat(chars, 9)
            .Select(s => s[random.Next(s.Length)]).ToArray());
    }

    private static string GetRandomSpecialNeedsDetails()
    {
        string[] specialNeeds = { "Wheelchair assistance", "Oxygen tank", "Service animal", "Dietary restrictions" };
        return specialNeeds[random.Next(specialNeeds.Length)];
    }

    public static List<Passenger> GeneratePassengers(int count, List<Flight> flights)
    {
        List<Passenger> passengers = new List<Passenger>();

        for (int i = 0; i < count; i++)
        {
            string firstName = GetRandomName();
            string lastName = GetRandomName();
            string passportNumber = GeneratePassportNumber();
            Flight flight = flights[random.Next(flights.Count)];
            bool specialNeeds = random.NextDouble() < 0.2; // 20% chance of having special needs
            string specialNeedsDetails = specialNeeds ? GetRandomSpecialNeedsDetails() : string.Empty;

            Passenger passenger = new Passenger(firstName, lastName, passportNumber, flight, specialNeeds, specialNeedsDetails);
            passengers.Add(passenger);
            flight.Passengers.Add(passenger); // Add the passenger to the flight's passenger list
        }

        return passengers;
    }

    public static List<Flight> GenerateFlights(int count)
    {
        List<Flight> flights = new List<Flight>();
        string[] origins = { "SFO", "LAX", "JFK", "ORD", "DFW", "ATL", "DEN", "SEA", "LAS", "MCO" };
        string[] destinations = { "SIN", "KUL", "BKK", "CGK", "HAN", "SGN", "MNL", "PNH", "VTE", "RGN" };

        for (int i = 0; i < count; i++)
        {
            string origin = origins[random.Next(origins.Length)];
            string destination = destinations[random.Next(destinations.Length)];
            DateTime departureTime = DateTime.Now;
            DateTime arrivalTime = DateTime.Now.AddHours(5);
            List<Passenger> flightPassengers = new List<Passenger>();
            string gate = $"G{random.Next(1, 100)}";

            Flight flight = new Flight($"FL{random.Next(100, 1000)}", origin, destination, departureTime, arrivalTime, flightPassengers, gate);
            flights.Add(flight);
        }

        return flights;
    }

    public static List<Baggage> GenerateBaggage(int count, List<Passenger> passengers)
    {
        List<Baggage> baggageList = new List<Baggage>();

        for (int i = 0; i < count; i++)
        {
            int id = i + 1;
            string baggageId = $"B{id:D3}";
            int weight = random.Next(5, 30);
            Passenger owner = passengers[random.Next(passengers.Count)];

            ScreeningStatus screeningStatus = (ScreeningStatus)random.Next(Enum.GetValues(typeof(ScreeningStatus)).Length);

            Baggage baggage = new Baggage(baggageId, weight, owner, screeningStatus, owner.Flight);
            baggageList.Add(baggage);
        }

        return baggageList;
    }

    public static List<SelfServiceKiosk> GenerateKiosks(int count)
    {
        List<SelfServiceKiosk> kiosks = new List<SelfServiceKiosk>();

        for (int i = 0; i < count; i++)
        {
            int id = i + 1;
            string kioskId = $"K{id:D3}";

            SelfServiceKiosk kiosk = new SelfServiceKiosk(id, kioskId);
            kiosks.Add(kiosk);
        }

        return kiosks;
    }

    public static List<Staff> GenerateStaff(int count)
    {
        List<Staff> staffList = new List<Staff>();
        string[] positions = { "Check-in Agent", "Gate Agent", "Customer Service" };

        for (int i = 0; i < count; i++)
        {
            int id = i + 1;
            string staffId = $"S{id:D3}";
            string firstName = GetRandomName();
            string lastName = GetRandomName();
            string position = positions[random.Next(positions.Length)];

            Staff staff = new Staff(staffId, firstName, lastName, position);
            staffList.Add(staff);
        }

        return staffList;
    }

    private static void PrintFlights(List<Flight> flights)
    {
        foreach (Flight flight in flights)
        {
            Console.WriteLine($"Flight Number: {flight.FlightNumber}, Origin: {flight.Origin}, Destination: {flight.Destination}");
        }
    }
}
