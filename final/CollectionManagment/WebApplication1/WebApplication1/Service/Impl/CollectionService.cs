using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.dto;
using WebApplication1.Models;

namespace WebApplication1.Service.Impl
{
    public class CollectionService:ICollectionService
    {
        private readonly AppDbContext context;

        public CollectionService(AppDbContext context)
        {
            this.context = context;
        }

        public Collection Create(Collection t)
        {
            context.Collection.Add(t);
            context.SaveChanges();
            return t;
        }

        public Collection Read(int id)
        {
            return context.Collection.Find(id);
        }

        public Collection Update(Collection t)
        {
            Collection collection = context.Collection.Find(t.Id);
            if (collection != null)
            {
                context.Collection.Update(t);
                context.SaveChanges();
                return collection;
            }
            return null;
        }

        public void Delete(int id)
        {
            context.Collection.Remove(context.Collection.Find(id));
            context.SaveChanges();
        }

        public void Delete(Collection t)
        {
            context.Collection.Remove(t);
            context.SaveChanges();
        }

        public bool IsExist(string name)
        {
            return context.Collection.Any(x=>x.Name==name);
        }

        public Collection GetByName(string name)
        {
            return context.Collection.First(x => x.Name == name);
        }

        public List<Collection> GetByType(CollectionType collectionType)
        {
            return context.Collection.Where(x=>x.TypeString == collectionType.ToString()).ToList();
        }

        public List<Collection> GetByUserIdAndType(int userId, CollectionType collectionType)
        {
            return context.Collection.Where(x =>x.UserId==userId && x.TypeString == collectionType.ToString()).ToList();
        }
    }
}
