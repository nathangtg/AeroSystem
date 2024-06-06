using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.BoardingPass;

namespace AeroSystem.models.SelfServiceKiosk
{
    public class SelfServiceKiosk
    {
        private int id;
        private string kioskId;

        public SelfServiceKiosk(int id, string kioskId)
        {
            this.id = id;
            this.kioskId = kioskId;
        }

        // ! Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string KioskId
        {
            get { return kioskId; }
            set { kioskId = value; }
        }

        // ! Methods
        public void selfCheckIn(Passenger.Passenger passenger, Flight.Flight flight)
        {
            Console.WriteLine("Passenger " + passenger.Id + " has checked in at kiosk " + kioskId + " for flight " + flight.FlightNumber);

            // Create boarding pass
            BoardingPass.BoardingPass boardingPass = new BoardingPass.BoardingPass(flight, "B2", DateTime.Now, DateTime.Now.AddHours(3), passenger);
        }

        public void printBoardingPass(Passenger.Passenger passenger, Flight.Flight flight, BoardingPass.BoardingPass boardingPass)
        {
            Console.WriteLine("Passenger " + passenger.Id + " has printed boarding pass " + boardingPass.BoardingPassId + " for flight " + flight.FlightNumber);

            // Show boarding pass
            Console.WriteLine("Boarding Pass ID: " + boardingPass.BoardingPassId);
            Console.WriteLine("Flight Number: " + flight.FlightNumber);
            Console.WriteLine("Seat Number: " + boardingPass.SeatNumber);
            Console.WriteLine("Gate: " + boardingPass.Gate);
            Console.WriteLine("Boarding Time: " + boardingPass.BoardingTime);
            Console.WriteLine("Departure Time: " + boardingPass.DepartureTime);

        }

    }
}