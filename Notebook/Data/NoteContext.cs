using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Notebook.Models;

namespace Notebook.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options) : base(options)
        {

        }

        public DbSet<Note> Notes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }

    
    }
}
