using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Services.IServices;
using MauiBlazorNote.ViewModel.Note;

namespace MauiBlazorNote.Services.Services
{
    public class NoteServices : BaseServices<NoteViewModel>, INoteServices
    {
        private INoteRepository _noteRepository;
        private INoteDto _dto;

        public NoteServices(INoteRepository noteRepository, INoteDto dto) : base(noteRepository, dto)
        {
            _noteRepository = noteRepository;
            _dto = dto;
        }
    }
}
