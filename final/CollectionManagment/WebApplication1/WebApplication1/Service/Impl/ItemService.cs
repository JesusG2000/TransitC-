using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class ItemService:IItemService
    {
        private readonly AppDbContext context;

        public ItemService(AppDbContext context)
        {
            this.context = context;
        }
        public Item Create(Item t)
        {
            context.Item.Add(t);
            context.SaveChanges();
            return t;
        }

        public Item Read(int id)
        {
            return context.Item.Find(id);
        }

        public Item Update(Item t)
        {
            Item item = context.Item.Find(t.Id);
            if (item != null)
            {
                context.Item.Update(t);
                context.SaveChanges();
                return item;
            }
            return null;
        }

        public void Delete(int id)
        {
            context.Item.Remove(context.Item.Find(id));
            context.SaveChanges();
        }

        public void Delete(Item t)
        {
            context.Item.Remove(t);
            context.SaveChanges();
        }
    }
}
