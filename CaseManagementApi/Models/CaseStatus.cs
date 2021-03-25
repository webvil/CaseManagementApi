using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CaseManagementApi.Models
{
    public partial class CaseStatus
    {
        public CaseStatus()
        {
            Cases = new HashSet<Cases>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Cases> Cases { get; set; }
    }
}
