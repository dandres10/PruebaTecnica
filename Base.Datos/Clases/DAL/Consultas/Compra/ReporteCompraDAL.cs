namespace Base.Datos.Clases.DAL.Consultas.Compra
{
    using Base.Datos.Clases.DO.Consultas;
    using Base.IC.Acciones.Consultas.Compra;
    using Base.IC.Clases;
    using Base.IC.DTO.Consultas.Compra;
    using Base.IC.Enumeraciones;
    using Base.IC.RecursosTxt.Querys;
    using Base.IC.RecursosTxt.Transversales;
    using Contexto;
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;

    public class ReporteCompraDAL : IReporteCompraAccion
    {
        private Respuesta<IReporteCompraDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public ReporteCompraDAL()
        {
            this.Respuesta = new Respuesta<IReporteCompraDTO>();
        }

        ~ReporteCompraDAL()
        {
            connection.Close();
            dataReader.Close();
        }

        public Respuesta<IReporteCompraDTO> ReporteCompra(IReporteCompraFiltroDTO reporteCompraFiltro)
        {
            using (connection = Contexto.GetInstance())
            {
                string query = string.Format(ReportesCompraQuery.ReporteCompra, reporteCompraFiltro.NumeroDocumento, reporteCompraFiltro.GuidPedido);
                using (command = new SQLiteCommand(query, connection))
                {
                    ExecuteRead(command);
                }
            }

            return Respuesta;
        }

        private void ExecuteRead(SQLiteCommand command)
        {
            List<ReporteCompra> reporteCompras = new List<ReporteCompra>();

            try
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ReporteCompra reporteCompra = new ReporteCompra
                        {
                            CantidadComic = Convert.ToInt32(dataReader["CantidadComic"].ToString()),
                            Celular = Convert.ToInt32(dataReader["Celular"].ToString()),
                            Comprador = dataReader["Comprador"].ToString(),
                            Direccion = dataReader["Direccion"].ToString(),
                            FechaCompra = Convert.ToDateTime(dataReader["FechaCompra"]),
                            NumeroDocumento = Convert.ToInt32(dataReader["NumeroDocumento"]),
                            Orden = dataReader["Orden"].ToString(),
                            TotalCompra = Convert.ToDouble(dataReader["TotalCompra"])
                        };
                        reporteCompras.Add(reporteCompra);
                    }
                    dataReader.Close();
                    connection.Close();
                }

                RespuestaExitoso(reporteCompras.First());
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                dataReader.Close();
                connection.Close();
            }
        }

        private void RespuestaExitoso(IReporteCompraDTO ReporteCompra)
        {
            List<IReporteCompraDTO> ReporteCompras = new List<IReporteCompraDTO>();
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.AgregadoCorrectamente);
            ReporteCompras.Add(ReporteCompra);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = ReporteCompras;
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Exitoso;
        }

        private void RespuestaFallido(Exception error)
        {
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.ErrorAlIngresarDatos);
            mensajes.Add(error.Message.ToString());

            Respuesta.Mensajes = mensajes;
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Fallida;
        }
    }
}