using Notebook.Models;

namespace Notebook.Services
{
    public interface INoteBookService
    {
        Task <IEnumerable<Note>> GetAll();

        void Add (Note note);

        Task <Note> Get(int id);

        void Delete(int id);

        void UpDate(Note note);
    }
}
