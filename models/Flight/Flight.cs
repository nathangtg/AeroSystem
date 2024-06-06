using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroSystem.models.Flight
{
    public class Flight
    {
        private int id;
        private string flightNumber;
        private string origin;
        private string destination;
        private DateTime EstimatedDepartureTime;
        private DateTime EstimtaedArrivalTime;
        private List<Passenger.Passenger> passengers;
        private string gate;

        public Flight(int id, string flightNumber, string origin, string destination, DateTime EstimatedDepartureTime, DateTime EstimtaedArrivalTime, List<Passenger.Passenger> passengers, string gate)
        {
            this.id = id;
            this.flightNumber = flightNumber;
            this.origin = origin;
            this.destination = destination;
            this.EstimatedDepartureTime = EstimatedDepartureTime;
            this.EstimtaedArrivalTime = EstimtaedArrivalTime;
            this.passengers = passengers;
            this.gate = gate;
        }

        // ! Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        public string Origin
        {
            get { return origin; }
            set { origin = value; }
        }

        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }

        public DateTime estimatedDepartureTime
        {
            get { return EstimatedDepartureTime; }
            set { EstimatedDepartureTime = value; }
        }

        public DateTime estimatedArrivalTime
        {
            get { return EstimtaedArrivalTime; }
            set { EstimtaedArrivalTime = value; }
        }

        public List<Passenger.Passenger> Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }

        public string Gate
        {
            get { return gate; }
            set { gate = value; }
        }

        // ! Methods
        public void updateFlightStatus()
        {
            Console.WriteLine("Flight " + flightNumber + " has been updated.");
        }

        public void displayPassengers()
        {
            foreach (Passenger.Passenger passenger in passengers)
            {
                Console.WriteLine(passenger.FirstName + " " + passenger.LastName + " is on this flight.");
            }
        }
    }
}