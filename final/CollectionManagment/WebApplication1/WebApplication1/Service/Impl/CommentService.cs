using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service.Impl
{
    public class CommentService:ICommentService
    {
        private readonly AppDbContext context;

        public CommentService(AppDbContext context)
        {
            this.context = context;
        }

        public Comment Create(Comment t)
        {
            context.Comment.Add(t);
            context.SaveChanges();
            return t;
        }

        public Comment Read(int id)
        {
            return context.Comment.Find(id);
        }

        public Comment Update(Comment t)
        {
            Comment comment = context.Comment.Find(t.Id);
            if (comment != null)
            {
                context.Comment.Update(t);
                context.SaveChanges();
                return comment;
            }
            return null;
        }

        public void Delete(int id)
        {
            context.Comment.Remove(context.Comment.Find(id));
            context.SaveChanges();
        }

        public void Delete(Comment t)
        {
            context.Comment.Remove(t);
            context.SaveChanges();
        }
    }
}
