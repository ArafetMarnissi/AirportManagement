using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public int PassportNumber { get; set; }
        public List<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "BirthDate : " + BirthDate
                + " FirstName : " + FirstName
                + " LastName : " + LastName
                + " TelNumber : " + TelNumber
                + " EmailAddress : " + EmailAddress
                + " PassportNumber : " + PassportNumber;
        }
    }
}
