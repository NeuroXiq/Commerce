using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commerce.Models
{
    public class Contractor
    {
        public int ID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [StringLength(20)]
        public string Street { get; set; }
        [StringLength(20)]
        public string City { get; set; }
        [StringLength(20)]
        public string Country { get; set; }
        [DisplayName("Tax number"), StringLength(20)]
        public string TaxNumber { get; set; }
        [DisplayName("NBRN"), StringLength(20)]
        public string NBRN { get; set; }
        [DisplayName("Bank account"), StringLength(20)]
        public string BankAccountNumber { get; set; }
    }
}
