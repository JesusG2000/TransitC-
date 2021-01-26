using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.dto;
using WebApplication1.Util;

namespace WebApplication1.Models
{
    public class Collection
    {
        [Key]
        public int Id { get; set; }

        [Column("Type")]
        public string TypeString
        {
            get { return CollectionType.ToString(); }
            private set { CollectionType = value.ParseEnum<CollectionType>(); }
        }

        [NotMapped]
        public CollectionType CollectionType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PathToImg { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }

    }
}
