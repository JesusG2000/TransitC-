using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Model
{
    public class Like
    {
        [Key]
        public int Id { get; set; }

        public int? ItemId { get; set; } 
        public int? UserId { get; set; }
       
        public Item Item { get; set; } 
        public User User { get; set; }
    }
}
