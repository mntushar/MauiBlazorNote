using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Services.IServices;
using MauiBlazorNote.ViewModel.Note;

namespace MauiBlazorNote.Services.Services
{
    public class NoteServices : BaseServices<NoteViewModel>, INoteServices
    {
        private INoteRepository _noteRepository;

        public NoteServices(INoteRepository noteRepository) : base(noteRepository)
        {
            _noteRepository = noteRepository;

        }
    }
}
