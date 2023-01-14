using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.ViewModel.Note;
using System.Linq.Expressions;

namespace MauiBlazorNote.Services.IServices
{
    public interface INoteServices
    {
        Task<bool> InsertItemAsync(NoteViewModel entity);
        Task<bool> UpdateItemAsync(NoteViewModel entity);
        Task<NoteViewModel> GetItemAsync(Expression<Func<NoteEntity, bool>> pedicate);
        Task<NoteViewModel> GetItemAsync(int id);
        Task<IEnumerable<NoteViewModel>> GetItemListAsync(Expression<Func<NoteEntity, bool>> pedicate);
        Task<IEnumerable<NoteViewModel>> GetItemListAsync(Expression<Func<NoteEntity, bool>> pedicate, int skip, int take);
        Task<IEnumerable<NoteViewModel>> GetItemListAsync();
        Task<IEnumerable<NoteViewModel>> GetItemListAsync(int skip, int take);
        Task<bool> DeleteItemAsync(int id);
    }
}
