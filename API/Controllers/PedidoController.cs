namespace API.Controllers
{
    using API.Models.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL.EntidadesRepositorio;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/Pedido")]
    public class PedidoController : ApiController
    {
        private PedidoBL pedidoBL;

        public PedidoController()
        {
            this.pedidoBL = new PedidoBL();
        }

        [HttpGet]
        [Route("ConsultarPedido")]
        public Respuesta<Pedido> ConsultarPedido(Pedido pedido)
        {
            return Mapeador(pedidoBL.ConsultarPedido(pedido));
        }

        [HttpPost]
        [Route("GuadarPedido")]
        public Respuesta<Pedido> GuadarPedido(List<Pedido> pedido)
        {
            return Mapeador(pedidoBL.GuadarPedido(MapeadorListaPedido(pedido)));
        }

        public List<IPedidoDTO> MapeadorListaPedido(List<Pedido> pedido)
        {
            List<IPedidoDTO> pedidoMapeado = new List<IPedidoDTO>();

            foreach (var item in pedido)
            {
                pedidoMapeado.Add(item);
            }

            return pedidoMapeado;
        }

        public Respuesta<Pedido> Mapeador(Respuesta<IPedidoDTO> respuesta)
        {
            List<Pedido> entidades = new List<Pedido>();

            foreach (IPedidoDTO item in respuesta.Entidades)
            {
                Pedido pedido = new Pedido
                {
                    Comic = item.Comic,
                    Guid = item.Guid,
                    Usuario = item.Usuario,
                    Valor = item.Valor,
                    Cantidad = item.Cantidad
                };
                entidades.Add(pedido);
            }

            Respuesta<Pedido> mapeador = new Respuesta<Pedido>
            {
                Entidades = entidades,
                Mensajes = respuesta.Mensajes,
                Resultado = respuesta.Resultado,
                TipoNotificacion = respuesta.TipoNotificacion
            };

            return mapeador;
        }
    }
}