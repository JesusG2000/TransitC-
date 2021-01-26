using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Impl
{
    public class FieldService:IFieldService
    {
        private readonly AppDbContext context;

        public FieldService(AppDbContext context)
        {
            this.context = context;
        }
        public Field Create(Field t)
        {
            context.Field.Add(t);
            context.SaveChanges();
            return t;
        }

        public Field Read(int id)
        {
            return context.Field.Find(id);
        }

        public Field Update(Field t)
        {
            Field field = context.Field.Find(t.Id);
            if (field != null)
            {
                context.Field.Update(t);
                context.SaveChanges();
                return field;
            }
            return null;
        }

        public void Delete(int id)
        {
            context.Field.Remove(context.Field.Find(id));
            context.SaveChanges();
        }

        public void Delete(Field t)
        {
            context.Field.Remove(t);
            context.SaveChanges();
        }

        public bool IsExist(int collectionId , string name)
        {
            return context.Field.Any(x => x.Name == name && x.CollectionId== collectionId);
        }

        public List<Field> GetAllByCollectionId(int id)
        {
            return context.Field.Where(x => x.CollectionId == id).ToList();
        }
    }
}
