using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.dto;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface ICollectionService:IService<Collection>
    {
        bool IsExist(string name);

        Collection GetByName(string name);
        List<Collection> GetByType(CollectionType collectionType);
        List<Collection> GetByUserIdAndType(int userId,CollectionType collectionType);
    }
}
