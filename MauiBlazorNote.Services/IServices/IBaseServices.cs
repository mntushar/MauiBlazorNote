using System.Linq.Expressions;

namespace MauiBlazorNote.Services.IServices
{
    public interface IBaseServices<TEntity> where TEntity : class
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> pedicate);
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> pedicate);
        Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take);
        Task<List<TEntity>> GetListAsync();
        Task<List<TEntity>> GetListAsync(int take, int skip);
        Task DeleteAsync(int id);
    }
}
