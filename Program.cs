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
        SelfServiceKiosk kiosk = new SelfServiceKiosk(1, "K001");

        int passengerCount = 0;
        while (true)
        {
            Console.Write("Enter number of passengers to generate: ");
            string? input = Console.ReadLine();
            if (input != null && int.TryParse(input, out passengerCount) && passengerCount > 0)
            {
                break;
            }
            Console.WriteLine("Invalid input. Please enter a positive integer.");
        }

        List<Flight> flights = GenerateFlights(5); // Generating 5 flights for selection
        List<Passenger> passengers = GeneratePassengers(passengerCount, flights);

        List<Baggage> baggageList = GenerateBaggage(passengerCount, passengers);
        List<Staff> staffList = GenerateStaff(3);

        // ! Interactive selection
        Console.WriteLine("Select a flight to check-in passengers:");
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

                Console.WriteLine("Options:");
                Console.WriteLine("1. Check-in Passengers");
                Console.WriteLine("2. Print Boarding Passes");
                Console.WriteLine("3. Print Baggage Information");
                Console.Write("Enter option number: ");

                int option;
                while (!int.TryParse(Console.ReadLine(), out option) || option < 1 || option > 3)
                {
                    Console.WriteLine("Invalid option. Please enter a number between 1 and 3.");
                    Console.Write("Enter option number: ");
                }
                Console.WriteLine("--------------");

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
                }
            }
        }


        Console.WriteLine($"Selected Flight: {selectedFlight?.FlightNumber} from {selectedFlight?.Origin} to {selectedFlight?.Destination}");

        // ! Check in passengers for the selected flight
        foreach (Passenger p in passengers.Where(p => p.Flight.FlightNumber == selectedFlight?.FlightNumber))
        {
            kiosk.selfCheckIn(p, p.Flight);
            BoardingPass boardingPass = new BoardingPass(p.Flight, "B2", DateTime.Now, DateTime.Now.AddHours(3), p);
            kiosk.printBoardingPass(p, p.Flight, boardingPass);
        }

        // ! Print out baggage information for the selected flight
        foreach (Baggage b in baggageList.Where(b => b.Flight.FlightNumber == selectedFlight?.FlightNumber))
        {
            Console.WriteLine($"Baggage ID: {b.BaggageId}, Weight: {b.Weight}, Owner: {b.Owner.FullName}, Flight: {b.Flight.FlightNumber}, Screening Status: {b.ScreeningStatus}");
        }
        Console.WriteLine("--------------");


        // ! Print staff information
        foreach (Staff s in staffList)
        {
            Console.WriteLine($"Staff ID: {s.StaffId}, Name: {s.FirstName} {s.LastName}, Position: {s.Position}");
        }
    }



    // ! Interactive selection helper
    // ! Interactive selection helper
    // ! Interactive selection helper
    // ! Interactive selection helper
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

    // ! Generator methods
    // ! Generator methods
    // ! Generator methods
    // ! Generator methods
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

            // ! Randomize the screening status
            ScreeningStatus screeningStatus = (ScreeningStatus)random.Next(Enum.GetValues(typeof(ScreeningStatus)).Length);

            Baggage baggage = new Baggage(baggageId, weight, owner, screeningStatus, owner.Flight);
            baggageList.Add(baggage);
        }

        return baggageList;
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
