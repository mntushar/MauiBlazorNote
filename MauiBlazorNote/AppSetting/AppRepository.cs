using MauiBlazorNote.Data.Entity;
using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Repository.Repository;

namespace MauiBlazorNote
{
    public static class AppRepository
    {
        public static MauiAppBuilder RegisterRepository(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<NoteEntity>();
            mauiAppBuilder.Services.AddTransient<INoteRepository, NoteRepository>();

            return mauiAppBuilder;
        }
    }
}