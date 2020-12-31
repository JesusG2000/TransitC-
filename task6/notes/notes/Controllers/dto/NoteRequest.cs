using notes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notes.Controllers
{
    public class NoteRequest
    {
        public Note Note { get; set; }
        public string ConnectionId { get; set; }
    }
}
