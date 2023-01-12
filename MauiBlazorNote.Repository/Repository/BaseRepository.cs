using MauiBlazorNote.Repository.IRepository;
using SQLite;
using System.Linq.Expressions;

namespace MauiBlazorNote.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private SQLiteAsyncConnection _database;

        public BaseRepository(IConstants constants)
        {
            _database = new SQLiteAsyncConnection(constants.GetDatabasePath(), constants.GetFlags());
        }

        public virtual async Task<TEntity> InsertItemAsync(TEntity entity)
        {
            await _database.InsertAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> UpdateItemAsync(TEntity entity)
        {
            await _database.UpdateAsync(entity);

            return entity;
        }

        public virtual async Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return await _database.Table<TEntity>().FirstOrDefaultAsync(pedicate);
        }

        public virtual async Task<TEntity> GetItemAsync(int id)
        {
            return await _database.Table<TEntity>().ElementAtAsync(id);
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return await _database.Table<TEntity>().Where(pedicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take)
        {
            return await _database.Table<TEntity>().Where(pedicate).Skip(take).Take(take).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemListAsync()
        {
            return await _database.Table<TEntity>().ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(int skip, int take)
        {
            return await _database.Table<TEntity>().Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task DeleteItemAsync(int id)
        {
            await _database.DeleteAsync(id);
        }
    }
}
