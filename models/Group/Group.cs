using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Passenger;

namespace AeroSystem.models.Group
{
    public class Group
    {
        private int id;
        private List<Passenger.Passenger> passengers;
        private Passenger.Passenger representative;

        public Group(int id, List<Passenger.Passenger> passengers, Passenger.Passenger representative)
        {
            this.id = id;
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