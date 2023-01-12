namespace MauiBlazorNote.Repository
{
    public interface IConstants
    {
        SQLite.SQLiteOpenFlags GetFlags();
        string GetDatabasePath();
    }
}
