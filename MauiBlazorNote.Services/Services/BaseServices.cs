using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Services.IServices;
using System.Linq.Expressions;

namespace MauiBlazorNote.Services.Services
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class, new()
    {
        private IBaseRepository<TEntity> _baseRepository;

        public BaseServices(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<TEntity> InsertAsync(TEntity entity)
        {
            return await _baseRepository.InsertItemAsync(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            return await _baseRepository.UpdateItemAsync(entity);
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return await _baseRepository.GetItemAsync(pedicate);
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _baseRepository.GetItemAsync(id);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return await _baseRepository.GetItemListAsync(pedicate);
        }

        public virtual async Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take)
        {
            return await _baseRepository.GetItemListAsync(pedicate, skip, take);
        }

        public virtual async Task<List<TEntity>> GetListAsync()
        {
            return await _baseRepository.GetItemListAsync();
        }

        public virtual async Task<List<TEntity>> GetListAsync(int take, int skip)
        {
            return await _baseRepository.GetItemListAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            await _baseRepository.DeleteItemAsync(id);
        }
    }
}
