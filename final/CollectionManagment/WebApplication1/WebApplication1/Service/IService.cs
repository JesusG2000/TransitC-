using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Service
{
    public interface IService<T>
    {
        T Create(T t);
        T Read(int id);
        T Update(T t);
        void Delete(int id);
        void Delete(T t);
    }
}
