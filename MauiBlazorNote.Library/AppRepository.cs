using MauiBlazorNote.Repository;
using MauiBlazorNote.Repository.IRepository;
using MauiBlazorNote.Repository.Repository;

namespace MauiBlazorNote.Library
{
    public static class AppRepository
    {
        public static MauiAppBuilder RegisterRepository(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<IConstants, Constants>();
            mauiAppBuilder.Services.AddTransient<INoteRepository, NoteRepository>();

            return mauiAppBuilder;
        }
    }
}