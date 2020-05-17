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

    public class CompraDAL : ICompraAccion
    {
        private Respuesta<ICompraDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public CompraDAL()
        {
            this.Respuesta = new Respuesta<ICompraDTO>();
        }

        ~CompraDAL()
        {
            connection.Close();
            dataReader.Close();
        }

        public Respuesta<ICompraDTO> GuadarCompra(ICompraDTO compra)
        {
            Compra compraObj = new Compra();
            using (connection = Contexto.GetInstance())
            {
                compraObj = Mapeador(compra);

                string query = CompraQuery.GuardarCompra;
                using (command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.Add(new SQLiteParameter("Fecha", compraObj.Fecha));
                    command.Parameters.Add(new SQLiteParameter("Total", compraObj.Total));
                    command.Parameters.Add(new SQLiteParameter("Pedido", compraObj.Pedido));

                    ExecuteNonQuery(command, compraObj);
                }

                return Respuesta;
            }
        }

        private void ExecuteNonQuery(SQLiteCommand command, ICompraDTO compra)
        {
            try
            {
                command.ExecuteNonQuery();
                RespuestaExitoso(compra);
            }
            catch (Exception error)
            {
                RespuestaFallido(error.Message.ToString());
            }
        }

        private void RespuestaExitoso(ICompraDTO compra)
        {
            List<ICompraDTO> compras = new List<ICompraDTO>();
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.AgregadoCorrectamente);
            compras.Add(compra);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = compras;
            Respuesta.Resultado = true;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Exitoso;
        }

        private void RespuestaFallido(string error)
        {
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.ErrorAlIngresarDatos);
            mensajes.Add(error.ToString());

            Respuesta.Mensajes = mensajes;
            Respuesta.Resultado = false;
            Respuesta.TipoNotificacion = (int)TipoNotificacion.Fallida;
        }

        private Compra Mapeador(ICompraDTO de)
        {
            return _ = new Compra
            {
                Fecha = de.Fecha,
                Id = de.Id,
                Pedido = de.Pedido,
                Total = de.Total
            };
        }
    }
}