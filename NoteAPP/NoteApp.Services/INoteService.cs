using NoteApp.Models;
using System.Collections.Generic;

namespace NoteApp.Services
{
    public interface INoteService
    {
        IEnumerable<NoteModel> GetUserNotes(int userId);
        NoteModel GetNote(int id, int userId);
        void AddNote(NoteModel note);
        void DeleteNote(int id, int userId);
    }
}
