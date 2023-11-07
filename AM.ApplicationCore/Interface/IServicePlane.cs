using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Plane = AM.ApplicationCore.Domain.Plane;

namespace AM.ApplicationCore.Interface
{
    public interface IServicePlane : IService<Plane>
    {
       IEnumerable<Passenger> GetPassengers (Plane plane);
       IEnumerable<Flight> GetFlights(int n);
        Boolean IsAvailablePlane(Flight flight,int n);
        void DeletePlane();
    }
}
