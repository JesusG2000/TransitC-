using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.dto;

namespace WebApplication1.Service
{
   public interface IUserRoleService:IService<UserRole>
    { 
        UserRole ReadByRole(RoleType role);
    }
}
