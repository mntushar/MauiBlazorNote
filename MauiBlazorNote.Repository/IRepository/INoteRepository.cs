using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.ViewModel.Note;
using System.Linq.Expressions;

namespace MauiBlazorNote.Repository.IRepository
{
    public interface INoteRepository : IBaseRepository<NoteEntity>
    {
    }
}
