using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {

        public int ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsLetter { get; set; }
        public MemberShipType MemberShipType { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Display (Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? BirthDate { get; set; }
        [Display (Name ="Membership Type")]
        public byte MemberShipTypeID { get; set; }
    }
}