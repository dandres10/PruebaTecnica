namespace Base.Datos.Contexto
{
    using System.Data.SQLite;

    public class Contexto
    {
        private const string DBName = "comicDB.db";

        public Contexto() { }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection("Data Source=C:/Users/dandr/Desktop/Prueba/PruebaTecnica/Base.Datos/Contexto/comicDB.db;");
            db.Open();

            return db;
        }

        public static void CloseConnection(SQLiteConnection db)
        {
            db.Close();
        }
    }
}