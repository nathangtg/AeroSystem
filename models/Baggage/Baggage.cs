using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AeroSystem.models.Flight;
using AeroSystem.models.Passenger;

namespace AeroSystem.models.Baggage
{
    public class Baggage
    {
        private int id;
        private string baggageId;
        private int weight;
        private Passenger.Passenger owner;
        private Flight.Flight flight;
        private string screeningStatus;

        public Baggage(int id, string baggageId, int weight, Passenger.Passenger owner, string screeningStatus, Flight.Flight flight)
        {
            this.id = id;
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

        public string ScreeningStatus
        {
            get { return screeningStatus; }
            set { screeningStatus = value; }
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

        public void updateScreeningStatus(string status)
        {
            this.screeningStatus = status;
            Console.WriteLine("The screening status of baggage " + baggageId + " has been updated to " + status);
        }
    }
}