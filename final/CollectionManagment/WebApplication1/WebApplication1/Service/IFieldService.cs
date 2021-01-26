using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IFieldService:IService<Field>
    {
        bool IsExist(int collectionId, string name);

        List<Field> GetAllByCollectionId(int id);
    }
}
