using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroSystem.models.Staff
{
    public class Staff
    {
        private static int lastId = 0;
        private int id;
        private string staffId;
        private string firstName;
        private string lastName;
        private string position;

        public Staff(string staffId, string firstName, string lastName, string position)
        {
            id = ++lastId;
            this.staffId = staffId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.position = position;
        }

        // ! Getters and Setters
        public int Id
        {
            get {return id;}
            set {id = value;}
        }

        public string StaffId
        {
            get {return staffId;}
            set {staffId = value;}
        }

        public string FirstName
        {
            get {return firstName;}
            set {firstName = value;}
        }

        public string LastName
        {
            get {return lastName;}
            set {lastName = value;}
        }

        public string Position
        {
            get {return position;}
            set {position = value;}
        }

        // ! Methods
        public void assistPassenger()
        {
            Console.WriteLine("Staff " + staffId + " is assisting a passenger.");
        }

        public void checkInPassenger()
        {
            Console.WriteLine("Staff " + staffId + " is checking in a passenger.");
        }

        public void manageCheckInCounter()
        {
            Console.WriteLine("Staff " + staffId + " is managing a check-in counter.");
        }

    }
}