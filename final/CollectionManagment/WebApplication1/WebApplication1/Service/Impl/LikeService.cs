using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.Service.Impl
{
    public class LikeService:ILikeService
    {
        private readonly AppDbContext context;

        public LikeService(AppDbContext context)
        {
            this.context = context;
        }
        public Like Create(Like t)
        {
            context.Like.Add(t);
            context.SaveChanges();
            return t;
        }

        public Like Read(int id)
        {
            return context.Like.Find(id);
        }

        public Like Update(Like t)
        {
            Like like = context.Like.Find(t.Id);
            if (like != null)
            {
                context.Like.Update(t);
                context.SaveChanges();
                return like;
            }
            return null;
        }

        public void Delete(int id)
        {
            context.Like.Remove(context.Like.Find(id));
            context.SaveChanges();
        }

        public void Delete(Like t)
        {
            context.Like.Remove(t);
            context.SaveChanges();
        }
    }
}
