namespace Base.Datos.Clases.DAL.EntidadesRepositorio
{
    using Base.Datos.Clases.DO.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Enumeraciones;
    using Base.IC.RecursosTxt.Querys;
    using Base.IC.RecursosTxt.Transversales;
    using Contexto;
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    public class ComicDAL : IComicAccion
    {
        private Respuesta<IComicDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public ComicDAL()
        {
            this.Respuesta = new Respuesta<IComicDTO>();
        }

        public Respuesta<IComicDTO> ConsultarComic(IComicDTO comic)
        {
            using (connection = Contexto.GetInstance())
            {
                string query = string.Format(ComicQuery.ConsultarComic, comic.Id);
                using (command = new SQLiteCommand(query, connection))
                {
                    ExecuteRead(command);
                }
            }

            return Respuesta;
        }

        public Respuesta<IComicDTO> GuadarComic(IComicDTO comic)
        {
            Comic comicObj = new Comic();
            using (connection = Contexto.GetInstance())
            {
                comicObj = Mapeador(comic);

                string query = ComicQuery.GuardarComic;
                using (command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("Id", comicObj.Id));
                    command.Parameters.Add(new SQLiteParameter("Nombre", comicObj.Nombre));
                    command.Parameters.Add(new SQLiteParameter("Autor", comicObj.Autor));
                    command.Parameters.Add(new SQLiteParameter("Fecha", comicObj.Fecha));

                    ExecuteNonQuery(command, comicObj);
                }

                return Respuesta;
            }
        }

        private Comic Mapeador(IComicDTO de)
        {
            return _ = new Comic
            {
                Nombre = de.Nombre,
                Autor = de.Autor,
                Fecha = de.Fecha,
                Id = de.Id
            };
        }

        private void ExecuteRead(SQLiteCommand command)
        {
            List<Comic> comics = new List<Comic>();

            try
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Comic comicObj = new Comic
                        {
                            Id = Convert.ToInt32(dataReader["id"].ToString()),
                            Nombre = dataReader["Nombre"].ToString(),
                            Autor = dataReader["Autor"].ToString(),
                            Fecha = Convert.ToDateTime(dataReader["Fecha"].ToString())
                        };
                        comics.Add(comicObj);
                    }
                    dataReader.Close();
                    connection.Close();
                }

                RespuestaExitoso(comics.First());
                
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                dataReader.Close();
                connection.Close();
            }
        }

        private void RespuestaExitoso(IComicDTO comic)
        {
            List<IComicDTO> comics = new List<IComicDTO>();
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.AgregadoCorrectamente);
            comics.Add(comic);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = comics;
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Exitoso;
        }

        private void RespuestaFallido(Exception error)
        {
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.ErrorAlIngresarDatos);
            mensajes.Add(error.ToString());

            Respuesta.Mensajes = mensajes;
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Fallida;
        }

        private void ExecuteNonQuery(SQLiteCommand command, IComicDTO comic)
        {
            try
            {
                command.ExecuteNonQuery();
                RespuestaExitoso(comic);
                connection.Close();
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                connection.Close();
            }
        }
    }
}