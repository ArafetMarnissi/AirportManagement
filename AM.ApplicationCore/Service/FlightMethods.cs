using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Service
{
    public class FlightMethods: IFlightMethods
    {
        public List<Flight> Flights { get; set; }= new List<Flight>();
        public Action<Plane> FlightDetailsDel;
        public Func<string,double> DurationAverageDel;

        public FlightMethods()
        {
            //FlightDetailsDel = ShowFlightDetails;
            FlightDetailsDel = pl =>
            {
                var req = from f in Flights where f.Plane == pl select new { f.FlightDate, f.Destination };
                foreach (var f in req)
                    Console.WriteLine(f);
            };
            // DurationAverageDel = DurationAverage;
            DurationAverageDel = D =>
            {
                var req = from f in Flights where f.Destination == D select f.EstimatedDuration;
                return req.Average();
            };
        }

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

            
            //dates = from f in Flights where f.Destination == destination select f.FlightDate;
            dates = Flights.Where(f=>f.Destination == destination).Select(f=>f.FlightDate);
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

        


        public void ShowFlightDetails(Plane plane)
        {
            //var req = from f in Flights where f.Plane == plane select new {f.FlightDate,f.Destination};
            var req = Flights.Where(f=>f.Plane == plane).Select(f=> new {f.FlightDate,f.Destination});
            foreach (var f in req)
                Console.WriteLine(f);
        }
        public int ProgrammedFlightNumber(DateTime startDate)
        {
            // var req = from f in Flights where ((f.FlightDate - startDate).TotalDays<=7  && (f.FlightDate - startDate).TotalDays >=0) select f;     
            var req=  Flights.Where(f => (f.FlightDate - startDate).TotalDays <= 7 && (f.FlightDate - startDate).TotalDays >= 0).Count();
            return req;

        }

        public double DurationAverage(string destination)
        {
            // var req = from f in Flights where f.Destination == destination select f.EstimatedDuration;
            var req=Flights.Where(f => f.Destination == destination).Average(f=>f.EstimatedDuration);
            return req;
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var req = from f in Flights select f ;
            return req.OrderByDescending(f => f.EstimatedDuration);
        }

        public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        {
            // var req = from t in flight.Passengers.OfType<Traveller>()
            //           orderby t.BirthDate
            //           select t;
            var req = flight.Passengers.OfType<Traveller>().OrderBy(t => t.BirthDate);
            return req.Take(3);            


        }

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            // var req = from f in Flights
            //           group f by f.Destination;
            var req = Flights.GroupBy(f => f.Destination);

            foreach (var g in req)
            {
                Console.WriteLine("Destination : "+g.Key);
                foreach (var f in g)
                    Console.WriteLine("décolage : "+f.FlightDate);
            }
            return req;
        }
    }
}
