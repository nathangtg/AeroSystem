using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroSystem.models.Passenger
{
    public class Passenger
    {
    private static int lastId = 0;
    private int id;
    private string firstName;
    private string lastName;
    private string passportNumber;
    private string flightDetails;
    private bool specialNeeds;
    private string specialNeedsDetails;

    // ! Constructors
    public Passenger(string firstName, string lastName, string passportNumber, string flightDetails, bool specialNeeds, string specialNeedsDetails)
    {
        id = ++lastId;
        this.firstName = firstName;
        this.lastName = lastName;
        this.passportNumber = passportNumber;
        this.flightDetails = flightDetails;
        this.specialNeeds = specialNeeds;
        this.specialNeedsDetails = specialNeedsDetails;
    }


        // ! Getters and Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string PassportNumber
        {
            get { return passportNumber; }
            set { passportNumber = value; }
        }

        public string FlightDetails
        {
            get { return flightDetails; }
            set { flightDetails = value; }
        }

        public bool SpecialNeeds
        {
            get { return specialNeeds; }
            set { specialNeeds = value; }
        }

        public string SpecialNeedsDetails
        {
            get { return specialNeedsDetails; }
            set { specialNeedsDetails = value; }
        }

        // ! Methods
        public void checkIn()
        {
            Console.WriteLine("Passenger has checked in");
        }

        public void generateBoardingPass()
        {
            Console.WriteLine("Boarding pass generated");
        }

        public string FullName
        {
            get { return firstName + " " + lastName; }
        }
    }
}