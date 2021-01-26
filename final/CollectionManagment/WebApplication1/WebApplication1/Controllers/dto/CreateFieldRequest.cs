using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers.dto
{
    public class CreateFieldRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FieldType { get; set; }
        public int CollectionId { get; set; }
    }
}
