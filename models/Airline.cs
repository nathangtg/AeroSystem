using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AeroSystem.models.Airline
{
    public class Airline
    {
        private static int lastId = 0;
        private int id;
        private string name;
        private string code;
        private List<Flight.Flight> flights;
        private string headquarters;
        private string country;
        private DateTime foundingDate;
        private string website;

        public Airline(string name, string code, string headquarters, string country, DateTime foundingDate, string website)
        {
            lastId++;
            id = lastId;
            this.name = name;
            this.code = code;
            flights = new List<Flight.Flight>();
            this.headquarters = headquarters;
            this.country = country;
            this.foundingDate = foundingDate;
            this.website = website;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public List<Flight.Flight> Flights
        {
            get { return flights; }
            set { flights = value; }
        }

        public string Headquarters
        {
            get { return headquarters; }
            set { headquarters = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public DateTime FoundingDate
        {
            get { return foundingDate; }
            set { foundingDate = value; }
        }

        public string Website
        {
            get { return website; }
            set { website = value; }
        }
    }
}