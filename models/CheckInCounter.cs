using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Flight;
using AeroSystem.models.Group;
using AeroSystem.models.Passenger;
using AeroSystem.models.Staff;

namespace AeroSystem.models.CheckInCounter
{
    public class CheckInCounter
    {
        private static int idCounter = 0;
        private int id;
        private string counterId;
        private Staff.Staff staff;

        public CheckInCounter(Staff.Staff staff)
        {
            id = ++idCounter;
            this.counterId = "C" + id.ToString("D3");
            this.staff = staff;
        }

        // Getters and Setters
        [System.ComponentModel.DataAnnotations.Key]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string CounterId
        {
            get { return counterId; }
            set { counterId = value; }
        }

        public Staff.Staff Staff
        {
            get { return staff; }
            set { staff = value; }
        }

        // Methods
        public void checkInPassenger(Passenger.Passenger passenger, Flight.Flight flight)
        {
            Console.WriteLine("Passenger " + passenger.Id + " has checked in at counter " + counterId + " for flight " + flight.FlightNumber);

            // Create boarding pass
            BoardingPass.BoardingPass boardingPass = new BoardingPass.BoardingPass(flight, "B2", DateTime.Now, DateTime.Now.AddHours(3), passenger);
        }

        public void checkinGroup(Group.Group group, Flight.Flight flight)
        {
            foreach (Passenger.Passenger passenger in group.Passengers)
            {
                checkInPassenger(passenger, flight);
            }
        }

    }
}