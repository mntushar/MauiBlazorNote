namespace MauiBlazorNote.ViewModel.Note
{
    public class NoteDto
    {
        public static Data.Entity.NoteEntity Map(NoteViewModel viewModel)
        {
            if (viewModel == null) { return null; }

            return new Data.Entity.NoteEntity
            {
                Id = viewModel.Id,
                Title = viewModel.Title,
                Note = viewModel.Note,
                IsDeactive = viewModel.IsDeactive,
                IsProtected = viewModel.IsProtected,
                UpdateDate = viewModel.UpdateDate,
                CreateDate = viewModel.CreateDate,
            };
        }

        public static NoteViewModel Map(Data.Entity.NoteEntity dataEntity)
        {
            if (dataEntity == null) { return null; }

            return new NoteViewModel
            {
                Id = dataEntity.Id,
                Title = dataEntity.Title,
                Note = dataEntity.Note,
                IsDeactive = dataEntity.IsDeactive,
                IsProtected = dataEntity.IsProtected,
                UpdateDate = dataEntity.UpdateDate,
                CreateDate = dataEntity.CreateDate,
            };
        }

        public static IEnumerable<NoteViewModel> Map(IEnumerable<Data.Entity.NoteEntity> dataEntityList)
        {
            if (dataEntityList == null) { yield break; }

            foreach (var item in dataEntityList)
            {
                yield return Map(item);
            }
        }
    }
}
