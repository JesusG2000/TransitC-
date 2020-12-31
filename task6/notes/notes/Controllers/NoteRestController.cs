using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using notes.Controllers.dto;
using notes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace notes.Controllers
{
   
    [ApiController]
    [Route("note")]
    public class NoteRestController : ControllerBase
    {
        private IHubContext<NoteHub> hubContext;
        private static List<Note> notes { get; }
        public NoteRestController(IHubContext<NoteHub> hubContext)
        {
            this.hubContext = hubContext;
        }
         static NoteRestController()
        {
            notes = new List<Note>();
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if (notes.Count == 0)
            {
                return NotFound();
            }
            return Ok(notes);
        }
        [HttpPost("{id}")]
        public async Task<ActionResult> IsExist(int id)
        {
           bool isExist = notes.Any(n => n.Id == id);
            if (isExist)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> Create(NoteRequest noteRequest )
        {
            notes.Add(noteRequest.Note);
            await hubContext.Clients.AllExcept(noteRequest.ConnectionId).SendAsync("Create", noteRequest.Note);
            return Ok();
        }
        [HttpPut]
        public async Task<ActionResult> Update(NoteRequest noteRequest)
        {
            Note previos = notes.FirstOrDefault(n => n.Id == noteRequest.Note.Id);
            int previosIndex = notes.IndexOf(previos);
            notes[previosIndex] = noteRequest.Note;
            await hubContext.Clients.AllExcept(noteRequest.ConnectionId).SendAsync("Update", noteRequest.Note);
            return Ok();

        }
        [HttpDelete]
        public async Task<ActionResult> Remove(NoteRemoveRequest noteRemove)
        {
            Note note = notes.Find(n => n.Id == noteRemove.Id);
            if (note == null)
            {
                return NotFound();
            }
            notes.Remove(note);
            await hubContext.Clients.AllExcept(noteRemove.ConnectionId).SendAsync("Delete", note);
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveById(int id)
        {
            Note note = notes.Find(n => n.Id == id);
            if (note == null)
            {
                return NotFound();
            }
            notes.Remove(note);
            return Ok();
        }
    }
}
