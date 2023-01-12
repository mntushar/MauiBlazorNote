using System.Linq.Expressions;

namespace MauiBlazorNote.Repository.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<TEntity> InsertItemAsync(TEntity entity);
        Task<TEntity> UpdateItemAsync(TEntity entity);
        Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> pedicate);
        Task<TEntity> GetItemAsync(int id);
        Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate);
        Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take);
        Task<List<TEntity>> GetItemListAsync();
        Task<List<TEntity>> GetItemListAsync(int skip, int take);
        Task DeleteItemAsync(int id);
    }
}
