using MauiBlazorNote.Services.IServices;
using Microsoft.AspNetCore.Components;

namespace MauiBlazorNote.Pages
{
    public partial class Index
    {
        [Inject]
        protected INoteServices NoteServices { get; set; }
    }
}
