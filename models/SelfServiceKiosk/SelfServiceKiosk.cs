using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public void selfCheckIn(Passenger.Passenger passenger)
        {
            Console.WriteLine("Passenger " + passenger.Id + " has been checked in.");
        }

        public void printBoardingPass(Passenger.Passenger passenger)
        {
            Console.WriteLine("Boarding pass for passenger " + passenger.Id + " has been printed.");
        }

    }
}