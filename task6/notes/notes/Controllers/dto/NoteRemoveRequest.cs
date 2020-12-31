using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notes.Controllers.dto
{
    public class NoteRemoveRequest
    {
        public int Id { get; set; }
        public string ConnectionId { get; set; }
    }
}
