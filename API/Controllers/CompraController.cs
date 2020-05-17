namespace API.Controllers
{
    using API.Models.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL.EntidadesRepositorio;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/Compra")]
    public class CompraController : ApiController
    {
        private CompraBL compraBL;

        public CompraController()
        {
            this.compraBL = new CompraBL();
        }

        [HttpPost]
        [Route("GuadarCompra")]
        public Respuesta<Compra> GuadarCompra(Compra compra)
        {
            return Mapeador(compraBL.GuadarCompra(compra));
        }

        public Respuesta<Compra> Mapeador(Respuesta<ICompraDTO> respuesta)
        {
            List<Compra> entidades = new List<Compra>();

            foreach (ICompraDTO item in respuesta.Entidades)
            {
                Compra compra = new Compra
                {
                    Fecha = item.Fecha,
                    Id = item.Id,
                    Pedido = item.Pedido,
                    Total = item.Total
                };
                entidades.Add(compra);
            }

            Respuesta<Compra> mapeador = new Respuesta<Compra>
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