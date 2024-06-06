// See https://aka.ms/new-console-template for more information

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
    // ! Random Number Generator
    private static Random random = new Random();

    // ! Main Method
    public static void Main(string[] args)
    {
        // ! Predefined Information
        SelfServiceKiosk kiosk = new SelfServiceKiosk(1, "K001");

        // ! Generate flights and passengers
        int passengerCount = 5;
        List<Flight> flights = GenerateFlights(passengerCount);
        List<Passenger> passengers = GeneratePassengers(passengerCount, flights);

        // ! Generate baggage
        List<Baggage> baggageList = GenerateBaggage(passengerCount, passengers);

        // ! Generate staff
        List<Staff> staffList = GenerateStaff(3);

        // ! Check in passengers
        foreach (Passenger p in passengers)
        {
            kiosk.selfCheckIn(p, p.Flight);
        }

        // ! Print boarding passes
        foreach (Passenger p in passengers)
        {
            BoardingPass boardingPass = new BoardingPass(p.Flight, "B2", DateTime.Now, DateTime.Now.AddHours(3), p);
            kiosk.printBoardingPass(p, p.Flight, boardingPass);
        }

        // ! Print Baggage Information
        foreach (Baggage b in baggageList)
        {
            Console.WriteLine($"Baggage ID: {b.BaggageId}, Weight: {b.Weight}, Owner: {b.Owner.FullName}, Flight: {b.Flight.FlightNumber}, Screening Status: {b.ScreeningStatus}");
        }

        // ! Print Staff Information
        foreach (Staff s in staffList)
        {
            Console.WriteLine($"Staff ID: {s.StaffId}, Name: {s.FirstName} {s.LastName}, Position: {s.Position}");
        }

    }

    // ! Information Generator Methods
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
            Flight flight = flights[i];
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

        // ! Generate random flights
        for (int i = 0; i < count; i++)
        {
            string origin = origins[random.Next(origins.Length)];
            string destination = destinations[random.Next(destinations.Length)];
            DateTime departureTime = DateTime.Now;
            DateTime arrivalTime = DateTime.Now.AddHours(5);
            List<Passenger> flightPassengers = new List<Passenger>();
            string gate = $"G{random.Next(1, 100)}";

            // ! Create a new Flight object
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
            int weight = random.Next(5, 30); // Random weight between 5 and 30 kg
            Passenger owner = passengers[random.Next(passengers.Count)];
            string screeningStatus = "Pending";

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
}
