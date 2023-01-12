using MauiBlazorNote.Services.IServices;
using MauiBlazorNote.ViewModel.Note;
using Microsoft.AspNetCore.Components;

namespace MauiBlazorNote.Pages
{
    public partial class Index
    {
        [Inject]
        protected INoteServices NoteServices { get; set; }

        protected override async Task OnInitializedAsync()
        {
            //var data = new NoteViewModel()
            //{
            //    Id = 1,
            //    Title = "Test",
            //    Note = "test",
            //    IsDeactive = true,
            //    IsProtected = true,
            //    UpdateDate = DateTime.Now,
            //    CreateDate = DateTime.Now,
            //};
            //await NoteServices.InsertAsync(data);
        }
    }
}
