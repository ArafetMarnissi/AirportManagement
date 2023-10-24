// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Service;
using AM.Infrastructure;

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
Passenger p1 = new Passenger { FullName =new FullName { FirstName="arafet", LastName="marnissi" }, EmailAddress="marnissiarafet@gmail.com"};
Console.WriteLine( p1.CheckProfile("arafet", "marnissi"));
Console.WriteLine(p1.CheckProfile("arafet", "marnissi","marnisiarafet@gmail.com"));
//tester passengerType
Staff s1 = new Staff();
Traveller tr = new Traveller();
p1.PassengerType();
s1.PassengerType();
tr.PassengerType();
FlightMethods flightMethods = new FlightMethods();
flightMethods.Flights = TestData.listFlights;
Console.WriteLine("*************GetFlightDates***************");


flightMethods.GetFlightDates("Paris");
Console.WriteLine("*************GetFlights***************");
flightMethods.GetFlights("Destination", "Madrid");
Console.WriteLine("*************ShowFlightDetails***************");
flightMethods.FlightDetailsDel(TestData.BoingPlane);
//flightMethods.ShowFlightDetails(TestData.BoingPlane);
Console.WriteLine("*************ProgrammedFlightNumber***************");
Console.WriteLine( flightMethods.ProgrammedFlightNumber(new DateTime(2022, 2, 1,10,10,0)));
Console.WriteLine("*************DurationAverage***************");

Console.WriteLine(flightMethods.DurationAverageDel("Paris"));
Console.WriteLine("*************OrderedDurationFlights***************");
foreach (Flight f in flightMethods.OrderedDurationFlights())
    Console.WriteLine(f.ToString());
/*Console.WriteLine("*************SeniorTravellers***************");
foreach (Passenger f in flightMethods.SeniorTravellers(TestData.flight2))
    Console.WriteLine(f.ToString());*/

Console.WriteLine("*************DestinationGroupedFlights***************");
flightMethods.DestinationGroupedFlights();
Console.WriteLine("*************UpperFullName***************");
p1.UpperFullName();
Console.WriteLine(p1.ToString());
//insertion de données
AMContext ctx = new AMContext();
/*ctx.Planes.Add(TestData.BoingPlane);
ctx.Planes.Add(TestData.Airbusplane);*/
///////////////////////////////////////////////
//inserion des deux Flights

/*ctx.Flights.Add(TestData.flight1);
ctx.Flights.Add(TestData.flight2);
//persistance de données
ctx.SaveChanges();
Console.WriteLine("Ajout avec succées");*/
///////////////////////////////////////////////

//Affichage de contenu
Console.WriteLine("****************Affichage de contenu******************");
foreach(Flight f in ctx.Flights)
    Console.WriteLine("Destination : "+f.Destination+" Date : "+ f.FlightDate+ "Capacity : "+f.Plane.Capacity);


