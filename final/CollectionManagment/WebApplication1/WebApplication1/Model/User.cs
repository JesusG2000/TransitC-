using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PathToImg { get; set; }
        [Required]
        public bool Block { get; set; }
        [Required]
        public int? RoleId { get;set; }
        [Required]
        public UserRole Role { get; set; }
       
    }
}
