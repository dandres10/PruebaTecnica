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

    public class ReporteCompraDetalleDAL : IReporteCompraDetalleAccion
    {
        private Respuesta<IReporteCompraDetalleDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public ReporteCompraDetalleDAL()
        {
            this.Respuesta = new Respuesta<IReporteCompraDetalleDTO>();
        }

        public Respuesta<IReporteCompraDetalleDTO> ReporteCompraDetalle(IReporteCompraDetalleFiltroDTO reporteCompraDetalleFiltro)
        {
            using (connection = Contexto.GetInstance())
            {
                string query = string.Format(ReportesCompraQuery.ReporteCompraDetalle, reporteCompraDetalleFiltro.NumeroDocumento, reporteCompraDetalleFiltro.GuidPedido);
                using (command = new SQLiteCommand(query, connection))
                {
                    ExecuteRead(command);
                }
            }

            return Respuesta;
        }

        private void ExecuteRead(SQLiteCommand command)
        {
            List<ReporteCompraDetalle> reporteComprasDetalles = new List<ReporteCompraDetalle>();

            try
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        ReporteCompraDetalle reporteCompradetalle = new ReporteCompraDetalle
                        {
                            CantidadComic = Convert.ToInt32(dataReader["CantidadComic"].ToString()),
                            NombreComic = dataReader["NombreComic"].ToString(),
                            ValorComic = Convert.ToDouble(dataReader["ValorComic"].ToString())
                        };
                        reporteComprasDetalles.Add(reporteCompradetalle);
                    }
                    dataReader.Close();
                    connection.Close();
                }

                RespuestaExitoso(MapeadorListaReporteCompraDetalle(reporteComprasDetalles));
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                dataReader.Close();
                connection.Close();
            }
        }

        private List<IReporteCompraDetalleDTO> MapeadorListaReporteCompraDetalle(List<ReporteCompraDetalle> reporteComprasDetalles)
        {
            List<IReporteCompraDetalleDTO> lista = new List<IReporteCompraDetalleDTO>();

            foreach (var item in reporteComprasDetalles)
            {
                lista.Add(item);
            }

            return lista;
        }

        private void RespuestaExitoso(List<IReporteCompraDetalleDTO> reporteComprasDetalles)
        {
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.AgregadoCorrectamente);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = reporteComprasDetalles;
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