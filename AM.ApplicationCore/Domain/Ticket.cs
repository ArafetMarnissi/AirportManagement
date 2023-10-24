using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Ticket
    {
        public long Prix { get; set; }
        public string Siege { get; set; }
        public bool Vip { get; set; }
        public virtual Passenger Passenger { get; set; }
        [ForeignKey("Passenger")]
        public int PassengerFk { get; set; }
        public virtual Flight Flight { get; set; }
        [ForeignKey("Flight")]
        public int FlightFk { get; set; }
    }
}
