namespace Base.IC.Acciones.EntidadesRepositorio
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using System.Collections.Generic;

    public interface IPedidoAccion
    {
        Respuesta<IPedidoDTO> GuadarPedido(List<IPedidoDTO> pedido);

        Respuesta<IPedidoDTO> ConsultarPedido(IPedidoDTO pedido);
    }
}