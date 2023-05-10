using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Entity.Identity
{
    public class AppUser : IdentityUser
    {
        public string NationalId { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string ThirdName { get; set; }
        public string FouthName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public IsActive IsActive { get; set; }
    }
}
