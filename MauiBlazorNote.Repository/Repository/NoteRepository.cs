using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.ViewModel.Note;
using SQLite;

namespace MauiBlazorNote.Repository.Repository
{
    public class NoteRepository : BaseRepository<NoteEntity>, INoteRepository
    {
        private SQLiteAsyncConnection _database;

        private async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.GetDatabasePath(), Constants.GetFlags());
            var result = await _database.CreateTableAsync<NoteEntity>();
        }
    }
}
