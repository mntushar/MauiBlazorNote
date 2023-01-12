namespace MauiBlazorNote.ViewModel.Note
{
    public interface INoteDto
    {
        Data.Entity.NoteEntity Map(NoteViewModel viewModel);
        NoteViewModel Map(Data.Entity.NoteEntity dataEntity);
        IEnumerable<NoteViewModel> Map(IEnumerable<Data.Entity.NoteEntity> dataEntityList);
    }
}
