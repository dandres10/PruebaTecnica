namespace Base.Datos.Clases.DAL.EntidadesRepositorio
{
    using Base.Datos.Clases.DO.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.IC.Enumeraciones;
    using Contexto;
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    public class TipoDocumentoDAL : ITipoDocumentoAccion
    {
        private Respuesta<ITipoDocumentoDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;

        public TipoDocumentoDAL()
        {
            this.Respuesta = new Respuesta<ITipoDocumentoDTO>();
        }

        public Respuesta<ITipoDocumentoDTO> GuadarTipoDocumento(ITipoDocumentoDTO tipoDocumento)
        {
            TipoDocumento tipoDocumentoObj = new TipoDocumento();
            using (connection = Contexto.GetInstance())
            {
                tipoDocumentoObj = Mapeador(tipoDocumento);
                RespuestaExitoso(tipoDocumentoObj);
                string query = "INSERT INTO TipoDocumento (Nombre,Codigo) VALUES (?,?)";
                using (command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("Nombre", tipoDocumentoObj.Nombre));
                    command.Parameters.Add(new SQLiteParameter("Codigo", tipoDocumentoObj.Codigo));

                    ExecuteNonQuery(command, tipoDocumentoObj);
                }

                return Respuesta;
            }
        }

        private TipoDocumento Mapeador(ITipoDocumentoDTO de)
        {
            TipoDocumento para;
            return para = new TipoDocumento
            {
                Codigo = de.Codigo,
                Nombre = de.Nombre
            };
        }

        private void RespuestaExitoso(ITipoDocumentoDTO tipoDocumento)
        {
            List<ITipoDocumentoDTO> tipoDocumentos = new List<ITipoDocumentoDTO>();
            List<string> mensajes = new List<string>();
            mensajes.Add("Agregado correctamente.");
            tipoDocumentos.Add(tipoDocumento);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = tipoDocumentos;
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Exitoso;
        }

        private void RespuestaFallido(ITipoDocumentoDTO tipoDocumento, Exception error)
        {
            List<ITipoDocumentoDTO> tipoDocumentos = new List<ITipoDocumentoDTO>();
            List<string> mensajes = new List<string>();
            mensajes.Add("Error al ingresar datos");
            mensajes.Add("Error: " + error);
            tipoDocumentos.Add(tipoDocumento);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = tipoDocumentos;
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Fallida;
        }

        private void ExecuteNonQuery(SQLiteCommand command, ITipoDocumentoDTO tipoDocumento)
        {
            try
            {
                command.ExecuteNonQuery();
                RespuestaExitoso(tipoDocumento);
            }
            catch (Exception error)
            {
                RespuestaFallido(tipoDocumento, error);
            }
        }
    }
}