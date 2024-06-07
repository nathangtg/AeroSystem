using AeroSystem.models.Airline;
using AeroSystem.models.Baggage;
using AeroSystem.models.BoardingPass;
using AeroSystem.models.CheckInCounter;
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
    List<Group> groupList = new List<Group>();
    List<Airline> airlines = new List<Airline>();
    List<SelfServiceKiosk> kiosks = GenerateKiosks(1);

    while (true)
    {
        Console.WriteLine("Menu:");
        Console.WriteLine("1. Generate Flights");
        Console.WriteLine("2. Generate Passengers");
        Console.WriteLine("3. Generate Kiosks");
        Console.WriteLine("4. Generate Groups");
        Console.WriteLine("5. Generate Staff");
        Console.WriteLine("6. Select Flight and Perform Operations");
        Console.WriteLine("7. Print Kiosks");
        Console.WriteLine("8. Print Staff");
        Console.WriteLine("9. Print Passengers");
        Console.WriteLine("10. Print Groups");

        Console.WriteLine("11. Generate Airlines");
        Console.WriteLine("12. Print Airlines");
        Console.WriteLine("13. Exit");
        Console.Write("Enter your choice: ");

        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            switch (choice)
            {
                case 1:
                    flights = GenerateFlights(GetPositiveIntegerInput("Enter number of flights to generate: "), airlines);
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
                    kiosks = GenerateKiosks(GetPositiveIntegerInput("Enter number of kiosks to generate: "));
                    break;
                case 4:
                    if (flights.Count == 0)
                    {
                        Console.WriteLine("No flights available. Please generate flights first.");
                    }
                    else
                    {
                        groupList = GenerateGroups(GetPositiveIntegerInput("Enter number of groups to generate: "), passengers);
                    }
                    break;
                case 5:
                    staffList = GenerateStaff(GetPositiveIntegerInput("Enter number of staff to generate: "));
                    break;
                case 6:
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
                        PerformFlightOperations(kiosks[0], flights, passengers, baggageList, staffList, groupList);
                    }
                    break;
                case 7:
                    PrintKiosks(kiosks);
                    break;
                case 8:
                    PrintStaff(staffList);
                    break;
                case 9:
                    PrintPassengers(passengers);
                    break;
                case 10:
                    PrintGroups(groupList);
                    break;
                case 11:
                    airlines = GenerateAirlines(GetPositiveIntegerInput("Enter number of airlines to generate: "));
                    break;
                case 12:
                    PrintAirlines(airlines);
                    break;
                case 13:
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

    private static void PerformFlightOperations(SelfServiceKiosk kiosk, List<Flight> flights, List<Passenger> passengers, List<Baggage> baggageList, List<Staff> staffList, List<Group> GroupList)
    {

        if (staffList.Count == 0)
        {
            Console.WriteLine("No staff available. Please generate staff first.");
            return;
        }

        Random random = new Random();
        Staff staff = staffList[random.Next(staffList.Count)]; 
        CheckInCounter checkInCounter = new CheckInCounter(staff);

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
                Console.WriteLine("--------------");
                Console.WriteLine($"Selected Flight: {selectedFlight.FlightNumber} from {selectedFlight.Origin} to {selectedFlight.Destination}");
                Console.WriteLine($"Airline: {selectedFlight.Airline.Name}");
                Console.WriteLine("Gate: " + selectedFlight.Gate);
                Console.WriteLine("Airline Code: " + selectedFlight.Airline.Code);
                Console.WriteLine("Estimated Departure Time: " + selectedFlight.EstimatedDepartureTime);
                Console.WriteLine("Estimated Arrival Time: " + selectedFlight.EstimatedArrivalTime);
                Console.WriteLine("--------------");

                while (true)
                {
                    Console.WriteLine("Options:");
                    Console.WriteLine("1. Check-in Passengers");
                    Console.WriteLine("2. Print Boarding Passes");
                    Console.WriteLine("3. Print Baggage Information");
                    Console.WriteLine("4. Check-in Group");
                    Console.WriteLine("5. Back to Main Menu");
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
                                CheckInGroup(checkInCounter, GroupList, selectedFlight);
                                break;
                            case 5:
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

    private static void CheckInGroup(CheckInCounter checkInCounter, List<Group> groups, Flight flight)
    {
        foreach (Group group in groups.Where(g => g.Representative.Flight.FlightNumber == flight.FlightNumber))
        {
            checkInCounter.checkinGroup(group, flight);
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
            bool specialNeeds = random.NextDouble() < 0.2; 
            string specialNeedsDetails = specialNeeds ? GetRandomSpecialNeedsDetails() : string.Empty;

            Passenger passenger = new Passenger(firstName, lastName, passportNumber, flight, specialNeeds, specialNeedsDetails);
            passengers.Add(passenger);
            flight.Passengers.Add(passenger); 
        }

        return passengers;
    }

    public static List<Group> GenerateGroups(int count, List<Passenger> passengers)
    {
        List<Group> groups = new List<Group>();

        for (int i = 0; i < count; i++)
        {
            int groupSize = random.Next(2, 6); 
            List<Passenger> groupPassengers = new List<Passenger>();

            List<Passenger> availablePassengers = new List<Passenger>(passengers);

            for (int j = 0; j < groupSize && availablePassengers.Count > 0; j++)
            {
                int index = random.Next(availablePassengers.Count);
                Passenger passenger = availablePassengers[index];
                groupPassengers.Add(passenger);
                availablePassengers.RemoveAt(index);
            }

            Passenger representative = groupPassengers[random.Next(groupPassengers.Count)];
            Group group = new Group(groupPassengers, representative);
            groups.Add(group);
        }

        return groups;
    }


    public static List<Flight> GenerateFlights(int count, List<Airline> airlines)
    {
        List<Flight> flights = new List<Flight>();
        string[] origins = { "SFO", "LAX", "JFK", "ORD", "DFW", "ATL", "DEN", "SEA", "LAS", "MCO", "YYZ", "YVR", "YYC", "YUL", "YEG", "YOW", "CDG", "LHR", "AMS", "FRA" };
        string[] destinations = { "SIN", "KUL", "BKK", "CGK", "HAN", "SGN", "MNL", "PNH", "VTE", "RGN", "DXB", "DOH", "IST", "AUH", "HKG", "PEK", "NRT", "ICN", "SYD", "AKL" };

        // Check if there are airlines available
        if (airlines.Count == 0)
        {
            Console.WriteLine("No airlines available. Please generate airlines first.");
            return flights;
        }

        for (int i = 0; i < count; i++)
        {
            string origin = origins[random.Next(origins.Length)];
            string destination = destinations[random.Next(destinations.Length)];
            DateTime departureTime = DateTime.Now;
            DateTime arrivalTime = DateTime.Now.AddHours(5);
            List<Passenger> flightPassengers = new List<Passenger>();
            string gate = $"G{random.Next(1, 100)}";

            // Select a random airline
            Airline randomAirline = airlines[random.Next(airlines.Count)];

            Flight flight = new Flight($"{randomAirline.Code}-{random.Next(100, 1000)}", origin, destination, departureTime, arrivalTime, flightPassengers, gate, randomAirline);
            flights.Add(flight);
        }

        return flights;
    }


    public static List<Airline> GenerateAirlines(int count) 
    {
        Dictionary<string, Tuple<string, string, DateTime, string>> airlineAssociations = new Dictionary<string, Tuple<string, string, DateTime, string>>()
            {
                { "Singapore Airlines", Tuple.Create("SQ", "Singapore", new DateTime(1972, 10, 1), "https://www.singaporeair.com/") },
                { "Qatar Airways", Tuple.Create("QR", "Qatar", new DateTime(1993, 11, 22), "https://www.qatarairways.com/") },
                { "Emirates", Tuple.Create("EK", "United Arab Emirates", new DateTime(1985, 3, 25), "https://www.emirates.com/") },
                { "Cathay Pacific", Tuple.Create("CX", "Hong Kong", new DateTime(1946, 9, 24), "https://www.cathaypacific.com/") },
                { "ANA", Tuple.Create("NH", "Japan", new DateTime(1952, 12, 27), "https://www.ana.co.jp/") },
                { "Lufthansa", Tuple.Create("LH", "Germany", new DateTime(1953, 1, 6), "https://www.lufthansa.com/") },
                { "British Airways", Tuple.Create("BA", "United Kingdom", new DateTime(1974, 4, 1), "https://www.britishairways.com/") },
                { "Air France", Tuple.Create("AF", "France", new DateTime(1933, 10, 7), "https://www.airfrance.com/") },
                { "KLM", Tuple.Create("KL", "Netherlands", new DateTime(1919, 10, 7), "https://www.klm.com/") },
                { "Qantas", Tuple.Create("QF", "Australia", new DateTime(1920, 11, 16), "https://www.qantas.com/") }
            };

        List<Airline> airlines = new List<Airline>();

        for (int i = 0; i < count; i++)
        {
            string airlineName = airlineAssociations.ElementAt(i).Key;
            Tuple<string, string, DateTime, string> airlineDetails = airlineAssociations.ElementAt(i).Value;

            Airline airline = new Airline(airlineName, airlineDetails.Item1, airlineDetails.Item2, airlineDetails.Item2, airlineDetails.Item3, airlineDetails.Item4);
            airlines.Add(airline);
        }

        return airlines;
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

    private static void PrintGroups(List<Group> groups)
    {
        foreach (Group group in groups)
        {
            Console.WriteLine($"Group Representative: {group.Representative.FullName}");
            Console.WriteLine("Group Members:");
            foreach (Passenger passenger in group.Passengers)
            {
                Console.WriteLine(passenger.FullName);
            }
            Console.WriteLine("--------------");
        }
    }

    private static void PrintAirlines(List<Airline> airlines)
    {
        foreach (Airline airline in airlines)
        {
            Console.WriteLine($"Airline: {airline.Name}, Code: {airline.Code}, Headquarters: {airline.Headquarters}, Country: {airline.Country}, Founding Date: {airline.FoundingDate}, Website: {airline.Website}");
        }
    }
}
