using DataBase.Entity.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Context
{
    public class AppIdentityUser : IdentityDbContext<AppUser>
    {
        public AppIdentityUser(DbContextOptions<AppIdentityUser> options) : base(options)
        {
        }
    }
}
