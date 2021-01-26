using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Model
{
    public class Item
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PathToImg { get; set; }
        public string Status { get; set; }
       
        public int BitMask { get; set; }
        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }
    }
}
