using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Flight;

namespace AeroSystem.models.BoardingPass
{
    public class BoardingPass
    {
        private static int id = 0;
        private string boardingPassId;
        private Flight.Flight flight;
        private string seatNumber;
        private string gate;
        private DateTime boardingTime;
        private DateTime departureTime;
        private Passenger.Passenger passenger;

        // ! Static Methods
        static BoardingPass()
        {
            id = 1; 
        }

        private string GenerateSeatNumber()
        {
            // Assuming an Airbus A320 with a 3-3 seating configuration
            int totalRows = 30; // Number of rows
            int rowLength = 6; // Number of seats per row

            // Generate a random row number between 1 and totalRows
            int rowNumber = new Random().Next(1, totalRows + 1);

            // Generate a random seat number within the row
            int seatNumber = new Random().Next(1, rowLength + 1);

            // Construct the seat number string
            string seatLetter = GetSeatLetter(seatNumber);
            return $"{rowNumber}{seatLetter}";
        }

        private string GetSeatLetter(int seatNumber)
        {
            // Convert seat number to corresponding seat letter
            switch (seatNumber)
            {
                case 1:
                case 4:
                    return "A";
                case 2:
                case 5:
                    return "B";
                case 3:
                case 6:
                    return "C";
                default:
                    throw new ArgumentException("Invalid seat number");
            }
        }

        // ! Constructor
        public BoardingPass(Flight.Flight flight, string gate, DateTime boardingTime, DateTime departureTime, Passenger.Passenger passenger)
        {
            id = id++; 
            this.boardingPassId = $"BP{id}"; 
            this.flight = flight;
            this.gate = gate;
            this.boardingTime = boardingTime;
            this.departureTime = departureTime;
            this.passenger = passenger;
            this.seatNumber = GenerateSeatNumber(); // Generate seat number
        }

        // ! Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BoardingPassId
        {
            get { return boardingPassId; }
            set { boardingPassId = value; }
        }

        public Flight.Flight Flight
        {
            get { return flight; }
            set { flight = value; }
        }

        public string SeatNumber
        {
            get { return seatNumber; }
            set { seatNumber = value; }
        }

        public string Gate
        {
            get { return gate; }
            set { gate = value; }
        }

        public DateTime BoardingTime
        {
            get { return boardingTime; }
            set { boardingTime = value; }
        }

        public DateTime DepartureTime
        {
            get { return departureTime; }
            set { departureTime = value; }
        }

        public Passenger.Passenger Passenger
        {
            get { return passenger; }
            set { passenger = value; }
        }


        // ! Methods
        public void printBoardingPass()
        {
            Console.WriteLine("Boarding pass " + boardingPassId + " has been printed.");
        }

        public void boardPassenger()
        {
            Console.WriteLine("Passenger has boarded the flight.");
        }
    }
}