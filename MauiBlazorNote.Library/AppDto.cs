using MauiBlazorNote.ViewModel.Note;

namespace MauiBlazorNote.Library
{
    public static class AppDto
    {
        public static MauiAppBuilder RegisterDto(this MauiAppBuilder mauiAppBuilder)
        {
            mauiAppBuilder.Services.AddTransient<INoteDto, NoteDto>();

            return mauiAppBuilder;
        }
    }
}
