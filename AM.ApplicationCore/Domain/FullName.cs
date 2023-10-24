using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MaxLength(25, ErrorMessage = "the max length is 25")]
        [MinLength(3, ErrorMessage = "the min length is 3")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
