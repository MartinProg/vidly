using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        //[Display(Name = "Date of Birth")]
        //[Min18YearsIfAMember]  // we commented this coz it's working on customer not customerdto"return to Min18 class"
        public Nullable<DateTime> birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        // Here we excluded MembershipType coz this is domain class and this property creating dependancy from our dto to our domain
        // properities should be only for primitive types or custom dtos
        //So if we we want MembershipType, then we should create another membershipTypeDTO
        //public MembershipType MembershipType { get; set; }

        //[Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}