using MauiBlazorNote.Repository.IRepository;
using SQLite;
using System.Linq.Expressions;

namespace MauiBlazorNote.Repository.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        private SQLiteAsyncConnection _database;
        private dynamic _dto;

        public BaseRepository(IConstants constants, dynamic dto)
        {
            _database = new SQLiteAsyncConnection(constants.GetDatabasePath(), constants.GetFlags());
            _dto = dto;
        }

        public virtual async Task<TEntity> InsertItemAsync(TEntity entity)
        {
           return _database.GetMappingAsync(await _database.InsertAsync(_dto.Map(entity)));
        }

        public virtual async Task<TEntity> UpdateItemAsync(TEntity entity)
        {
            return _dto.Map(await _database.UpdateAsync(_dto.Map(entity)));
        }

        public virtual async Task<TEntity> GetItemAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return _dto.Map(await _database.Table<TEntity>().FirstOrDefaultAsync(pedicate));
        }

        public virtual async Task<TEntity> GetItemAsync(int id)
        {
            return _dto.Map(await _database.Table<TEntity>().ElementAtAsync(id));
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate)
        {
            return _dto.Map(await _database.Table<TEntity>().Where(pedicate).ToListAsync());
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(Expression<Func<TEntity, bool>> pedicate, int skip, int take)
        {
            return _dto.Map(await _database.Table<TEntity>().Where(pedicate).Skip(take).Take(take).ToListAsync());
        }

        public virtual async Task<List<TEntity>> GetItemListAsync()
        {
            return _dto.Map(await _database.Table<TEntity>().ToListAsync());
        }

        public virtual async Task<List<TEntity>> GetItemListAsync(int skip, int take)
        {
            return _dto.Map(await _database.Table<TEntity>().Skip(skip).Take(take).ToListAsync());
        }

        public virtual async Task<bool> DeleteItemAsync(int id)
        {
            return await _database.DeleteAsync(id) > 0 ? true : false;
        }
    }
}
