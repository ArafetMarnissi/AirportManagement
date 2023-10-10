using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public DateTime BirthDate { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int TelNumber { get; set; }
        public string EmailAddress { get; set; }
        public int PassportNumber { get; set; }
        public ICollection<Flight> Flights { get; set; }

        public override string? ToString()
        {
            return "BirthDate : " + BirthDate
                + " FirstName : " + FirstName
                + " LastName : " + LastName
                + " TelNumber : " + TelNumber
                + " EmailAddress : " + EmailAddress
                + " PassportNumber : " + PassportNumber;
        }
        public Boolean CheckProfile(string prenom,string nom)
        {
            return(FirstName.Equals(prenom) && LastName.Equals(nom));
        }
       /* public Boolean CheckProfile(string prenom, string nom, string email)
        {
            return (FirstName.Equals(prenom) && LastName.Equals(nom) && EmailAddress.Equals(email));
        }
        public Boolean CheckProfile(string prenom, string nom)
        {
            return (FirstName.Equals(prenom) && LastName.Equals(nom));
        }*/
        public Boolean CheckProfile(string prenom, string nom, string email = null)
        {
            if(email != null)
            {
                return (FirstName.Equals(prenom) && LastName.Equals(nom) && EmailAddress.Equals(email));

            }
            else {
                return (FirstName.Equals(prenom) && LastName.Equals(nom));

            }
           
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("i'm a passenger");
        }
    }
}
