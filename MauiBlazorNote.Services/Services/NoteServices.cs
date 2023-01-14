using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Services.IServices;
using MauiBlazorNote.ViewModel.Note;
using System.Linq.Expressions;

namespace MauiBlazorNote.Services.Services
{
    public class NoteServices : INoteServices
    {
        private INoteRepository _noteRepository;

        public NoteServices(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public virtual async Task<bool> InsertItemAsync(NoteViewModel entity)
        {
            return await _noteRepository.InsertItemAsync(NoteDto.Map(entity));
        }

        public virtual async Task<bool> UpdateItemAsync(NoteViewModel entity)
        {
            return await _noteRepository.UpdateItemAsync(NoteDto.Map(entity));
        }

        public virtual async Task<NoteViewModel> GetItemAsync(Expression<Func<NoteEntity, bool>> pedicate)
        {
            return NoteDto.Map(await _noteRepository.GetItemAsync(pedicate));
        }

        public virtual async Task<NoteViewModel> GetItemAsync(int id)
        {
            return NoteDto.Map(await _noteRepository.GetItemAsync(id));
        }

        public virtual async Task<IEnumerable<NoteViewModel>> GetItemListAsync(Expression<Func<NoteEntity, bool>> pedicate)
        {
            return NoteDto.Map(await _noteRepository.GetItemListAsync(pedicate));
        }

        public virtual async Task<IEnumerable<NoteViewModel>> GetItemListAsync(Expression<Func<NoteEntity, bool>> pedicate, int skip, int take)
        {
            return NoteDto.Map(await _noteRepository.GetItemListAsync(pedicate, skip, take));
        }

        public virtual async Task<IEnumerable<NoteViewModel>> GetItemListAsync()
        {
            return NoteDto.Map(await _noteRepository.GetItemListAsync());
        }

        public virtual async Task<IEnumerable<NoteViewModel>> GetItemListAsync(int skip, int take)
        {
            return NoteDto.Map(await _noteRepository.GetItemListAsync(skip, take));
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            return await _noteRepository.DeleteItemAsync(id);
        }
    }
}
