using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Passenger;

namespace AeroSystem.models.Group
{
    public class Group
    {
        private int lastId = 0;
        private int id;
        private List<Passenger.Passenger> passengers;
        private Passenger.Passenger representative;

        public Group(List<Passenger.Passenger> passengers, Passenger.Passenger representative)
        {
            id = ++lastId;
            this.passengers = passengers;
            this.representative = representative;
        }

        // ! Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public List<Passenger.Passenger> Passengers
        {
            get { return passengers; }
            set { passengers = value; }
        }

        public Passenger.Passenger Representative
        {
            get { return representative; }
            set { representative = value; }
        }

        // ! Methods
        public void groupCheckIn()
        {
            foreach (Passenger.Passenger passenger in passengers)
            {
                Console.WriteLine(passenger.FirstName + " " + passenger.LastName + " has checked in.");                
            }
        }

        public void assignRepresentative(Passenger.Passenger representative)
        {
            this.representative = representative;
            Console.WriteLine("The representative for this group is " + representative.FirstName + " " + representative.LastName);
        }
    }
}