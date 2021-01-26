using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.dto;

namespace WebApplication1.Service.Impl
{
    public class UserRoleService : IUserRoleService
    {
        private readonly AppDbContext context;
       

        public UserRoleService(AppDbContext context)
        {
            this.context = context;
        }
        public UserRole Create(UserRole t)
        {
            context.UserRole.Add(t);
            context.SaveChanges();
            return t;
        }

        public void Delete(int id)
        {
            context.UserRole.Remove(context.UserRole.Find(id));
            context.SaveChanges();
        }

        public void Delete(UserRole t)
        {
            context.UserRole.Remove(t);
            context.SaveChanges();
        }

        public UserRole Read(int id)
        {
            return context.UserRole.Find(id);
        }

        public UserRole ReadByRole(RoleType role)
        {
            return context.UserRole.FirstOrDefault(r => r.RoleString == role.ToString());
        }

        public UserRole Update(UserRole t)
        {
            UserRole userRole = context.UserRole.Find(t.Id);
            if (userRole != null)
            {
                context.UserRole.Update(t);
                context.SaveChanges();
                return userRole;
            }
            return null;
        }
    }
}
