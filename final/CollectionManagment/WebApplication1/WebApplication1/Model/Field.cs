using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Models.dto;
using WebApplication1.Util;

namespace WebApplication1.Models
{
    public class Field
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        [Column("Type")]
        public string TypeString
        {
            get { return Type.ToString(); }
            private set { Type = value.ParseEnum<FieldType>(); }
        }
        [NotMapped]
        public FieldType Type { get; set; }
        public int? ItemId { get; set; }
        public int? CollectionId { get; set; }
        public Item Item { get; set; }
        public Collection Collection { get; set; }
    }
}
