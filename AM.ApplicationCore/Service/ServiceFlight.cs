using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Service
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IEnumerable<Flight> SortFlights()
        {
            return GetMany().OrderBy(f => f.Destination);
        }
    }
}
