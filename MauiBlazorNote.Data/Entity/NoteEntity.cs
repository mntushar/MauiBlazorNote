using SQLite;

namespace MauiBlazorNote.Data.Entity
{
    public class NoteEntity
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Note { get; set; }
        public bool IsDeactive { get; set; }
        public bool IsProtected { get; set; }
        public string UpdateDate { get; set; }
        public string CreateDate { get; set; }
    }
}
