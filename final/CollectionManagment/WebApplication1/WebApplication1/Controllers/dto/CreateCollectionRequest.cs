using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model.dto;

namespace WebApplication1.Controllers.dto
{
    public class CreateCollectionRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CollectionType { get; set; }
        public string PathToImg { get; set; }
        public int UserId { get; set; }
    }
}
