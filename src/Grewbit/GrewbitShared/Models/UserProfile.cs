using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrewbitShared.Models
{
    public class UserProfile
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public DateTime JoinDate { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Address { get; set; }

        public User User { get; set; }
    }
}
