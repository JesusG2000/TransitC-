using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
   public interface IUserService : IService<User>
    {
        bool IsExist(User user);
        User GetByLogin(string login);
        User GetByLoginAndPassword(string login, string password);

        List<User> GetAll();
    }
}
