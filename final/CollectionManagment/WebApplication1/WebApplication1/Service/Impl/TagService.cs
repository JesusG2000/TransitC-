using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Impl
{
    public class TagService:ITagService
    {
        private readonly AppDbContext context;

        public TagService(AppDbContext context)
        {
            this.context = context;
        }
        public Tag Create(Tag t)
        {
            context.Tag.Add(t);
            context.SaveChanges();
            return t;
        }

        public Tag Read(int id)
        {
            return context.Tag.Find(id);
        }

        public Tag Update(Tag t)
        {
            Tag tag = context.Tag.Find(t.Id);
            if (tag != null)
            {
                context.Tag.Update(t);
                context.SaveChanges();
                return tag;
            }
            return null;
        }

        public void Delete(int id)
        {
            context.Tag.Remove(context.Tag.Find(id));
            context.SaveChanges();
        }

        public void Delete(Tag t)
        {
            context.Tag.Remove(t);
            context.SaveChanges();
        }
    }
}
