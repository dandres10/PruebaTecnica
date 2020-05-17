namespace Base.Datos.Contexto
{
    using System.Data.SQLite;

    public class Contexto
    {
        public Contexto()
        {
        }

        public static SQLiteConnection GetInstance()
        {
            var db = new SQLiteConnection("Data Source=C:/Users/dandr/Desktop/Prueba/PruebaTecnica/Base.Datos/Contexto/comicDB.db;Version=3;New=False;Compress=True;");
            db.Open();

            return db;
        }
    }
}