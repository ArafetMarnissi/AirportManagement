using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interface
{
    public interface IFlightMethods
    {
        public IEnumerable<DateTime> GetFlightDates(string destination);
        void GetFlights(string filterType, string filterValue);
    }
}
