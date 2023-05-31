using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Notebook.Data;
using Notebook.Models;

namespace Notebook.Services
{
    public class NoteBookService : INoteBookService
    {
        List<Note> notes;
        private readonly NoteContext _context;

        public NoteBookService(NoteContext context)
        {
            notes = new List<Note>()
            { new Note {Id = 1, Title ="Appoitment", Description ="Dentist on 10.06.2023 at 10:00 a.m."},
              new Note {Id = 2, Title = "Meeting", Description= "Customer on 5.06.2023 at 9:00 a.m."},
              new Note {Id = 3, Title = "Party", Description = "Bday Party on 1.06.2023 at 5:00 p.m."}
            };
        }

        public async void Add(Note note)
        {
          
            await _context.Notes.AddAsync(note);
            note.Id = notes.Max(n => n.Id) + 1;
            await _context.SaveChangesAsync();
            
        }

        public async Task<Note> Get(int id)
        {
            return await _context.Notes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _context.Notes.OrderBy(r => r.Title).ToListAsync();
        }

        public async void Delete(int id)
        {
            var note = await Get(id);

            if (note != null)
            {
                _context.Notes.Remove(note);
                await _context.SaveChangesAsync();
            }
        }
    
         public async void UpDate(Note note)
        {
           var existingNote= await Get(note.Id);
            
            if (existingNote != null)
            {
                existingNote.Title = note.Title;
                existingNote.Description = note.Description;
            }
            await _context.SaveChangesAsync();
        }
    }
}
