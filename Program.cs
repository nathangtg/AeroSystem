// See https://aka.ms/new-console-template for more information

using AeroSystem.models.BoardingPass;
using AeroSystem.models.Flight;
using AeroSystem.models.Group;
using AeroSystem.models.Passenger;
using AeroSystem.models.SelfServiceKiosk;

using System.Collections.Generic;


 public class Program
    {
        // ! Random Number Generator
        private static Random random = new Random();

        // ! Main Method
        public static void Main(string[] args)
        {
            // ! Predefined Information
            SelfServiceKiosk kiosk = new SelfServiceKiosk(1, "K001");
            Passenger passenger = new Passenger("John", "Doe", "123456", "Flight 123", false, "");
            List<Passenger> passengerList = new List<Passenger> { passenger };
            Flight flight2 = new Flight("FL002", "SFO", "MIA", DateTime.Now, DateTime.Now.AddHours(5), passengerList, "B2");

            kiosk.selfCheckIn(passenger, flight2);
            kiosk.printBoardingPass(passenger, flight2, new BoardingPass(flight2, "B2", DateTime.Now, DateTime.Now.AddHours(3), passenger));
        }

        // ! Information Generator Methods
        private static string GetRandomName()
        {
            string[] names = { "John", "Emily", "Michael", "Sophia", "William", "Emma", "David", "Olivia", "James", "Ava" };
            return names[random.Next(names.Length)];
        }

        private static string GeneratePassportNumber()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 9)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string GetRandomSpecialNeedsDetails()
        {
            string[] specialNeeds = { "Wheelchair assistance", "Oxygen tank", "Service animal", "Dietary restrictions" };
            return specialNeeds[random.Next(specialNeeds.Length)];
        }
    }


