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

    public class PedidoDAL : IPedidoAccion
    {
        private Respuesta<IPedidoDTO> Respuesta;
        private SQLiteConnection connection;
        private SQLiteCommand command;
        private SQLiteDataReader dataReader;

        public PedidoDAL()
        {
            this.Respuesta = new Respuesta<IPedidoDTO>();
        }

        public Respuesta<IPedidoDTO> GuadarPedido(List<IPedidoDTO> pedido)
        {
            List<Pedido> pedidoObj = new List<Pedido>();
            using (connection = Contexto.GetInstance())
            {
                pedidoObj = Mapeador(pedido);

                string query = PedidoQuery.GuardarPedido;

                foreach (Pedido item in pedidoObj)
                {
                    using (command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.Add(new SQLiteParameter("Guid", item.Guid));
                        command.Parameters.Add(new SQLiteParameter("Comic", item.Comic));
                        command.Parameters.Add(new SQLiteParameter("Valor", item.Valor));
                        command.Parameters.Add(new SQLiteParameter("Usuario", item.Usuario));

                        ExecuteNonQuery(command, pedido);
                    }
                }
                connection.Close();
                return Respuesta;
            }
        }

        public Respuesta<IPedidoDTO> ConsultarPedido(IPedidoDTO pedido)
        {
            using (connection = Contexto.GetInstance())
            {
                string query = string.Format(PedidoQuery.ConsultarPedido, pedido.Guid);
                using (command = new SQLiteCommand(query, connection))
                {
                    ExecuteRead(command);
                }
            }

            return Respuesta;
        }

        private void ExecuteRead(SQLiteCommand command)
        {
            List<IPedidoDTO> pedidos = new List<IPedidoDTO>();

            try
            {
                using (dataReader = command.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        Pedido pedidoObj = new Pedido
                        {
                            Guid = dataReader["Guid"].ToString(),
                            Comic = Convert.ToInt32(dataReader["Comic"].ToString()),
                            Usuario = Convert.ToInt32(dataReader["Usuario"].ToString()),
                            Valor = Convert.ToDouble(dataReader["Valor"].ToString())
                        };
                        pedidos.Add(pedidoObj);
                    }
                    
                }
                dataReader.Close();
                connection.Close();

                RespuestaExitoso(pedidos);
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                dataReader.Close();
                connection.Close();
            }
        }

        private void RespuestaExitoso(List<IPedidoDTO> comic)
        {
            List<string> mensajes = new List<string>();
            mensajes.Add(Mensajes.AgregadoCorrectamente);

            Respuesta.Mensajes = mensajes;
            Respuesta.Entidades = comic;
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

        private void ExecuteNonQuery(SQLiteCommand command, List<IPedidoDTO> pedido)
        {
            try
            {
                command.ExecuteNonQuery();
                RespuestaExitoso(pedido);
                
            }
            catch (Exception error)
            {
                RespuestaFallido(error);
                connection.Close();
            }
        }

        private List<Pedido> Mapeador(List<IPedidoDTO> de)
        {
            List<Pedido> listaPedidos = new List<Pedido>();

            foreach (var item in de)
            {
                Pedido pedido = new Pedido
                {
                    Guid = item.Guid,
                    Comic = item.Comic,
                    Usuario = item.Usuario,
                    Valor = item.Valor
                };

                listaPedidos.Add(pedido);
            }

            return listaPedidos;
        }
    }
}