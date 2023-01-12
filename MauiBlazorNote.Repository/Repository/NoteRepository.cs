using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.ViewModel.Note;
using SQLite;

namespace MauiBlazorNote.Repository.Repository
{
    public class NoteRepository : BaseRepository<NoteViewModel>, INoteRepository
    {
        private SQLiteAsyncConnection _database;
        private IConstants _contants;
        private dynamic _dto;

        public NoteRepository(IConstants constants, INoteDto dto) : base(constants, dto)
        {
            _contants = constants;
            _dto = dto;
        }

        private async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(_contants.GetDatabasePath(), _contants.GetFlags());
            var result = await _database.CreateTableAsync<NoteEntity>();
        }
    }
}
