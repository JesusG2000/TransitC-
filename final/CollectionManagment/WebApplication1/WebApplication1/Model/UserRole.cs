using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.dto;
using WebApplication1.Util;

namespace WebApplication1.Models
{
   
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("Role")]
        public string RoleString
        {
            get { return RoleType.ToString(); }
            private set { RoleType = value.ParseEnum<RoleType>(); }
        }
        [Required]
        [NotMapped]
        public RoleType RoleType { get; set; }
        
       
    }
}
