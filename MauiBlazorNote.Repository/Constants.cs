namespace MauiBlazorNote.Repository
{
    public class Constants : IConstants
    {
        public const string DatabaseFilename = "TodoSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public SQLite.SQLiteOpenFlags GetFlags() => Flags;

        public string GetDatabasePath() => Path.Combine(FileSystem.AppDataDirectory, DatabaseFilename);
    }
}
