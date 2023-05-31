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
            context = _context;
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
