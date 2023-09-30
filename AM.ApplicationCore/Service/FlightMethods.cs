using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class FlightMethods: IFlightMethods
    {
        public List<Flight> Flights { get; set; }= new List<Flight>();

        public IEnumerable<DateTime> GetFlightDates(string destination)
        {
            IEnumerable<DateTime> dates = new List<DateTime>();
            /* foreach (Flight f in Flights)
             {
                 if (f.Destination == destination)
                 {
                     dates.Add(f.FlightDate);
                 }
             }*/
            dates = from f in Flights where f.Destination == destination select f.FlightDate;
            return dates;
        }

        public void GetFlights(string filterType, string filterValue)
        {
            switch(filterType)
            {
                case "Destination":
                    {
                        foreach (Flight f in Flights)
                            if(f.Destination.Equals(filterValue))
                                Console.WriteLine(f);
                        break;
                    }
                case "Departure":
                    {
                        foreach (Flight f in Flights)
                            if (f.Departure.Equals(filterValue))
                                Console.WriteLine(f);
                        break;
                    }
                case "EstimatedDuration":
                    {
                        foreach (Flight f in Flights)
                            if (f.EstimatedDuration.Equals(int.Parse(filterValue)))
                                Console.WriteLine(f);
                        break;
                    }
                case "FlightDate":
                    {
                        foreach (Flight f in Flights)
                            if (f.FlightDate.Equals(DateTime.Parse( filterValue)))
                                Console.WriteLine(f);
                        break;
                    }
            }
        }
    }
}
