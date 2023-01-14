using MauiBlazorNote.Repository.IRepository;
using SQLite;
using System.Linq.Expressions;

namespace MauiBlazorNote.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private SQLiteAsyncConnection _database;

        private async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.GetDatabasePath(), Constants.GetFlags());
            var result = await _database.CreateTableAsync<TEntity>();
        }

        public virtual async Task<bool> InsertItemAsync(TEntity entity)
        {
            await Init();
            return await _database.InsertAsync(entity) > 0 ? true : false;
        }

        public virtual async Task<bool> UpdateItemAsync(TEntity entity)
        {
            await Init();
            return await _database.UpdateAsync(entity) > 0 ? true : false;
        }

        public virtual async Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            await Init();
            return await _database.Table<TEntity>().FirstOrDefaultAsync(pedicate);
        }

        public virtual async Task<TEntity> GetItemAsync(int id)
        {
            await Init();

            TEntity result = null;

            try
            {
                result = await _database.Table<TEntity>().ElementAtAsync(id);
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            await Init();
            return await _database.Table<TEntity>().Where(pedicate).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take)
        {
            await Init();
            return await _database.Table<TEntity>().Where(pedicate).Skip(take).Take(take).ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemListAsync()
        {
            await Init();
            return await _database.Table<TEntity>().ToListAsync();
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(int skip, int take)
        {
            await Init();
            return await _database.Table<TEntity>().Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            await Init();

            bool result = false;

            try
            {
                result = await _database.DeleteAsync(id) > 0 ? true : false;
            }
            catch (Exception)
            {
                return result;
            }

            return result;
        }
    }
}
