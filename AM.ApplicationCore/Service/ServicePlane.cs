using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeletePlane()
        {
            /*IEnumerable<Plane> planes = GetMany(p => (DateTime.Now - p.ManufactureDate).TotalDays >= 3650);
            foreach (Plane plane in planes)
            {
                Delete(plane);
            }*/
            Delete(p => (DateTime.Now - p.ManufactureDate).TotalDays >= 3650);
        }

        public IEnumerable<Flight> GetFlights(int n)
        {
            IEnumerable<Plane> planes = GetMany();
            return planes.OrderByDescending(p => p.PlaneId).Take(n).SelectMany(p=>p.Flights).OrderByDescending(p=>p.FlightDate);
        }

        public IEnumerable<Passenger> GetPassengers(Plane plane)
        {
            return plane.Flights.SelectMany(t => t.Tickets).Select(p => p.Passenger);
        }

        public bool IsAvailablePlane(Flight flight, int n)
        {
            return flight.Plane.Capacity >= n+ flight.Tickets.Count();
        }
    }
}
