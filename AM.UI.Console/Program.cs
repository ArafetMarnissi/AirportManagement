// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Service;

Console.WriteLine("Hello, World!");
Plane plane = new Plane();
plane.Capacity = 100;
Console.WriteLine(plane.Capacity);
plane.ManufactureDate = DateTime.Now;
plane.PlaneType = PlaneType.Boeing;

//initialiseur d'objets
Plane plane2 = new Plane
{
    Capacity = 100,
    ManufactureDate = new DateTime(2023,10,30),
};
Console.WriteLine(plane2.ToString());
//tester checkProfile()
Passenger p1 = new Passenger { FirstName ="arafet", LastName="marnissi", EmailAddress="marnissiarafet@gmail.com"};
Console.WriteLine( p1.CheckProfile("arafet", "marnissi"));
Console.WriteLine(p1.CheckProfile("arafet", "marnissi","marnisiarafet@gmail.com"));
//tester passengerType
Staff s1 = new Staff();
Traveller tr = new Traveller();
p1.PassengerType();
s1.PassengerType();
tr.PassengerType();
Console.WriteLine("*************GetFlightDates***************");
FlightMethods flightMethods = new FlightMethods();
flightMethods.Flights = TestData.listFlights;
flightMethods.GetFlightDates("Madrid");
Console.WriteLine("*************GetFlights***************");
flightMethods.GetFlights("Destination", "Madrid");