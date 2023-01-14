using MauiBlazorNote.Services.IServices;
using MauiBlazorNote.Services.Services;

namespace MauiBlazorNote
{
    public static class AppServices
    {
        public static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<INoteServices, NoteServices>();

            return mauiAppBuilder;
        }
    }
}