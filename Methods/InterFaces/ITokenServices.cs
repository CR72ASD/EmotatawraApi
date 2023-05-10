using DataBase.Entity.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods.InterFaces
{
    public interface ITokenServices
    {
        Task<string> CreateToken(AppUser user,UserManager<AppUser> userManager);
    }
}
