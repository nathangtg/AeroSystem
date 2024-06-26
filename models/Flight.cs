namespace AeroSystem.models.Flight
{
    public class Flight
    {
        private static int nextId = 1; // Static field to track the next available ID
        private int id;
        private string flightNumber;
        private string origin;
        private string destination;
        private DateTime estimatedDepartureTime;
        private DateTime estimatedArrivalTime;
        private List<Passenger.Passenger> passengers;
        private string gate;
        private Airline.Airline airline;

        // ! Static Methods
        static Flight()
        {
            nextId = 1;
        }

        // ! Constructor Methods
        public Flight(string flightNumber, string origin, string destination, DateTime estimatedDepartureTime, DateTime estimatedArrivalTime, List<Passenger.Passenger> passengers, string gate, Airline.Airline airline)
        {
            this.id = nextId++; // Assign the current value of nextId and increment it
            this.flightNumber = flightNumber;
            this.origin = origin;
            this.destination = destination;
            this.estimatedDepartureTime = estimatedDepartureTime;
            this.estimatedArrivalTime = estimatedArrivalTime;
            this.passengers = passengers;
            this.gate = gate;
            this.airline = airline;
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

        public DateTime EstimatedDepartureTime
        {
            get { return estimatedDepartureTime; }
            set { estimatedDepartureTime = value; }
        }

        public DateTime EstimatedArrivalTime
        {
            get { return estimatedArrivalTime; }
            set { estimatedArrivalTime = value; }
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

        public Airline.Airline Airline
        {
            get { return airline; }
            set { airline = value; }
        }

        // ! Methods
        public void UpdateFlightStatus()
        {
            Console.WriteLine("Flight " + flightNumber + " has been updated.");
        }

        public void DisplayPassengers()
        {
            foreach (Passenger.Passenger passenger in passengers)
            {
                Console.WriteLine(passenger.FirstName + " " + passenger.LastName + " is on this flight.");
            }
        }

    }
}