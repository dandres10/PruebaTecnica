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

    public class UsuarioDAL : IUsuarioAccion
    {
        private Respuesta<IUsuarioDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public UsuarioDAL()
        {
            this.Respuesta = new Respuesta<IUsuarioDTO>();
        }

        public Respuesta<IUsuarioDTO> ConsultarUsuario(IUsuarioDTO usuario)
        {
            using (connection = Contexto.GetInstance())
            {
                string query = string.Format(UsuarioQuery.ColsultarUsuario, usuario.Id);
                using (command = new SQLiteCommand(query, connection))
                {
                    ExecuteRead(command);
                }
            }

            return Respuesta;
        }

        public Respuesta<IUsuarioDTO> GuadarUsuario(IUsuarioDTO usuario)
        {
            Usuario usuarioObj = new Usuario();
            using (connection = Contexto.GetInstance())
            {
                usuarioObj = Mapeador(usuario);

                string query = UsuarioQuery.InsertUsuario;
                using (command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("Nombre", usuarioObj.Nombre));
                    command.Parameters.Add(new SQLiteParameter("NumeroDocumento", usuarioObj.NumeroDocumento));
                    command.Parameters.Add(new SQLiteParameter("Direccion", usuarioObj.Direccion));
                    command.Parameters.Add(new SQLiteParameter("Celular", usuarioObj.Celular));
                    command.Parameters.Add(new SQLiteParameter("TipoDocumento", usuarioObj.TipoDocumento));

                    ExecuteNonQuery(command, usuarioObj);
                }

                return Respuesta;
            }
        }

        private Usuario Mapeador(IUsuarioDTO de)
        {
            return _ = new Usuario
            {
                Nombre = de.Nombre,
                Celular = de.Celular,
                Direccion = de.Direccion,
                NumeroDocumento = de.NumeroDocumento,
                TipoDocumento = de.TipoDocumento
            };
        }

        private void RespuestaExitoso(IUsuarioDTO usuario)
        {
            List<IUsuarioDTO> usuarios = new List<IUsuarioDTO>();
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.AgregadoCorrectamente);
            usuarios.Add(usuario);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = usuarios;
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

        private void ExecuteNonQuery(SQLiteCommand command, IUsuarioDTO usuario)
        {
            IUsuarioDTO usuarioId;

            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                using (connection = Contexto.GetInstance())
                {
                    string query = string.Format("SELECT * FROM Usuario where NumeroDocumento={0}", usuario.NumeroDocumento);
                    using (command = new SQLiteCommand(query, connection))
                    {
                        usuarioId = ExecuteReadSinRespuesta(command);
                    }
                }

                RespuestaExitoso(usuarioId);
                
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                connection.Close();
            }
        }

        private void ExecuteRead(SQLiteCommand command)
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Usuario usuarioObj = new Usuario
                        {
                            Id = Convert.ToInt32(dataReader["id"].ToString()),
                            Celular = Convert.ToInt32(dataReader["Celular"].ToString()),
                            Direccion = dataReader["Direccion"].ToString(),
                            Nombre = dataReader["Nombre"].ToString(),
                            NumeroDocumento = Convert.ToInt32(dataReader["NumeroDocumento"].ToString()),
                            TipoDocumento = Convert.ToInt32(dataReader["TipoDocumento"].ToString())
                        };
                        usuarios.Add(usuarioObj);
                    }
                    dataReader.Close();
                }

                RespuestaExitoso(usuarios.First());
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                dataReader.Close();
            }
        }

        private IUsuarioDTO ExecuteReadSinRespuesta(SQLiteCommand command)
        {
            List<IUsuarioDTO> usuarios = new List<IUsuarioDTO>();

            using (dataReader = command.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Usuario usuarioObj = new Usuario
                    {
                        Id = Convert.ToInt32(dataReader["id"].ToString()),
                        Celular = Convert.ToInt32(dataReader["Celular"].ToString()),
                        Direccion = dataReader["Direccion"].ToString(),
                        Nombre = dataReader["Nombre"].ToString(),
                        NumeroDocumento = Convert.ToInt32(dataReader["NumeroDocumento"].ToString()),
                        TipoDocumento = Convert.ToInt32(dataReader["TipoDocumento"].ToString())
                    };
                    usuarios.Add(usuarioObj);
                }
                dataReader.Close();
            }

            return usuarios.First();
        }
    }
}