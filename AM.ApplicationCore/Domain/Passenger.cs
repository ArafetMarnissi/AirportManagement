using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        [Key]
        [StringLength(7)]
        public int PassportNumber { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        public FullName FullName { get; set; }

        [RegularExpression("^[0-9](8)$")]
        public int TelNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
       
        public virtual ICollection<Ticket> Tickets { get; set; }

        public override string? ToString()
        {
            return "BirthDate : " + BirthDate
                + " FirstName : " + FullName.FirstName
                + " LastName : " + FullName.LastName
                + " TelNumber : " + TelNumber
                + " EmailAddress : " + EmailAddress
                + " PassportNumber : " + PassportNumber;
        }
        public Boolean CheckProfile(string prenom,string nom)
        {
            return(FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom));
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
                return (FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom) && EmailAddress.Equals(email));

            }
            else {
                return (FullName.FirstName.Equals(prenom) && FullName.LastName.Equals(nom));

            }
           
        }
        public virtual void PassengerType()
        {
            Console.WriteLine("i'm a passenger");
        }
    }
}
