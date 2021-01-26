using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        public string Value { get; set; }
        public int? ItemId { get; set; }
        public Item Item { get; set; }
    }
}
