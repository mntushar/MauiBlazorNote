using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Services.IServices;
using System.Linq.Expressions;

namespace MauiBlazorNote.Services.Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;
        private dynamic _dto;

        public BaseServices(IBaseRepository<TEntity> baseRepository, dynamic dto)
        {
            _baseRepository = baseRepository;
            _dto = dto;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await _baseRepository.InsertItemAsync(_dto.Map(entity));
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _baseRepository.UpdateItemAsync(_dto.Map(entity));
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return _dto.Map(await _baseRepository.GetItemAsync(pedicate));
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return _dto.Map(await _baseRepository.GetItemAsync(id));
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return _dto.Map(await _baseRepository.GetItemListAsync(pedicate));
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take)
        {
            return _dto.Map(await _baseRepository.GetItemListAsync(pedicate, skip, take));
        }

        public virtual async Task<List<TEntity>> GetListAsync()
        {
            return _dto.Map(await _baseRepository.GetItemListAsync());
        }

        public virtual async Task<List<TEntity>> GetListAsync(int take, int skip)
        {
            return _dto.Map(await _baseRepository.GetItemListAsync());
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _baseRepository.DeleteItemAsync(id);
        }
    }
}
