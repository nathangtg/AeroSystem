using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Group;
using AeroSystem.models.Passenger;
using AeroSystem.models.Staff;

namespace AeroSystem.models.CheckInCounter
{
    public class CheckInCounter
    {
        private int id;
        private string counterId;
        private Staff.Staff staff;

        public CheckInCounter(int id, string counterId, Staff.Staff staff)
        {
            this.id = id;
            this.counterId = counterId;
            this.staff = staff;
        }

        // ! Getters and Setters
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

        // ! Methods
        public void checkInPassenger(Passenger.Passenger passenger)
        {
            Console.WriteLine("Passenger " + passenger.Id + " has been checked in.");
        }

        public void checkinGroup(Group.Group group)
        {
            foreach (Passenger.Passenger passenger in group.Passengers)
            {
                checkInPassenger(passenger);
            }
        }

    }
}