using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>()
      .HasOne(e => e.Item)
      .WithMany()
      .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Like>()
      .HasOne(e => e.User)
      .WithMany()
      .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Field>()
      .HasOne(e => e.Item)
      .WithMany()
      .OnDelete(DeleteBehavior.Restrict); 
            
            modelBuilder.Entity<Field>()
      .HasOne(e => e.Collection)
      .WithMany()
      .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<User> User { get; set; }
        public DbSet<Like> Like { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Field> Field { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Tag> Tag { get; set; }


    }
}
