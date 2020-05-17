namespace Base.Negocio.Clases.BL.EntidadesRepositorio
{
    using Base.Datos.Clases.DAL.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System;
    using System.Collections.Generic;

    public class PedidoBL : IPedidoAccion
    {
        private PedidoDAL pedidoDAL;

        public PedidoBL()
        {
            this.pedidoDAL = new PedidoDAL();
        }

        public Respuesta<IPedidoDTO> ConsultarPedido(IPedidoDTO pedido)
        {
            return pedidoDAL.ConsultarPedido(pedido);
        }

        public Respuesta<IPedidoDTO> GuadarPedido(List<IPedidoDTO> pedido)
        {
            return pedidoDAL.GuadarPedido(AsignarCodigoPedido(pedido));
        }

        private List<IPedidoDTO> AsignarCodigoPedido(List<IPedidoDTO> pedido)
        {
            Guid codPedido = Guid.NewGuid();

            foreach (IPedidoDTO item in pedido)
            {
                item.Guid = codPedido.ToString();
            }

            return pedido;
        }
    }
}