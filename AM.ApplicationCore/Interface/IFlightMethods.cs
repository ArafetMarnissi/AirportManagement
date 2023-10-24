﻿using AM.ApplicationCore.Domain;
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
        void ShowFlightDetails(Plane plane);
        int ProgrammedFlightNumber(DateTime startDate);
        double DurationAverage(string destination);
        IEnumerable<Flight> OrderedDurationFlights();
        //IEnumerable<Passenger> SeniorTravellers(Flight flight);
        IEnumerable<IGrouping<String, Flight>> DestinationGroupedFlights();



    }
}
