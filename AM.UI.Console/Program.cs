// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;


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

