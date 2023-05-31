using Microsoft.EntityFrameworkCore;
using Notebook.Models;

namespace Notebook.Data
{
    public class DbInitializer
    {
        public static void Initialize(NoteContext context)
        {
            context.Database.EnsureCreated();
            if (context.Notes.Any())
            {
                return;
            }
            var notes = new Note[]

            { new Note {Id = 1, Title ="Appoitment", Description ="Dentist on 10.06.2023 at 10:00 a.m.", Created = DateTime.Now},
              new Note {Id = 2, Title = "Meeting", Description= "Customer on 5.06.2023 at 9:00 a.m.", Created = DateTime.Now},
              new Note {Id = 3, Title = "Party", Description = "Bday Party on 1.06.2023 at 5:00 p.m.", Created = DateTime.Now}
            };
            foreach (Note n in notes)
            {
                context.Notes.Add(n);
            }
            context.SaveChanges();
          
        }
    }
}
