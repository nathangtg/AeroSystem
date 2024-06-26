using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Flight;
using AeroSystem.models.Passenger;

namespace AeroSystem.models.Baggage
{
    public enum ScreeningStatus
    {
        Pending,
        Cleared,
        Suspicious
    }

    public class Baggage
    {

        private static int lastId = 0;
        private int id;
        private string baggageId;
        private int weight;
        private Passenger.Passenger owner;
        private Flight.Flight flight;
        private ScreeningStatus screeningStatus;

        // ! Static constructor

        // ! Constructors
        public Baggage(string baggageId, int weight, Passenger.Passenger owner, ScreeningStatus screeningStatus, Flight.Flight flight)
        {
            id = ++lastId;
            this.baggageId = baggageId;
            this.weight = weight;
            this.owner = owner;
            this.screeningStatus = screeningStatus;
            this.flight = flight;
        }

        // ! Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string BaggageId
        {
            get { return baggageId; }
            set { baggageId = value; }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; }
        }

        public Passenger.Passenger Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public ScreeningStatus ScreeningStatus
        {
            get { return screeningStatus; }
            set { screeningStatus = value; }
        }

        public Flight.Flight Flight
        {
            get { return flight; }
            set { flight = value; }
        }

        // ! Methods
        public void screenBaggage()
        {
            Console.WriteLine("Baggage " + baggageId + " has been screened.");
        }

        public void assignOwner(Passenger.Passenger owner)
        {
            this.owner = owner;
            Console.WriteLine("The owner of this baggage is " + owner.FirstName + " " + owner.LastName);
        }

        public void updateScreeningStatus(ScreeningStatus status)
        {
            screeningStatus = status;
            Console.WriteLine("The screening status of baggage " + baggageId + " has been updated to " + status);
        }
    }
}