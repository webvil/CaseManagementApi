using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CaseManagementApi.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Cases = new HashSet<Cases>();
            Comments = new HashSet<Comments>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
