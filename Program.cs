// See https://aka.ms/new-console-template for more information

using AeroSystem.models.BoardingPass;
using AeroSystem.models.Flight;
using AeroSystem.models.Passenger;
using AeroSystem.models.SelfServiceKiosk;

SelfServiceKiosk kiosk = new SelfServiceKiosk(1, "K001");
Passenger passenger = new Passenger(1, "John", "Doe", "123456", "Flight 123", false, "");
List<Passenger> passengerList = new List<Passenger> { passenger };
Flight flight2 = new Flight("FL002", "SFO", "MIA", DateTime.Now, DateTime.Now.AddHours(5), passengerList, "B2");

kiosk.selfCheckIn(passenger, flight2);
kiosk.printBoardingPass(passenger, flight2, new BoardingPass(flight2, "B2", DateTime.Now, DateTime.Now.AddHours(3), passenger));


