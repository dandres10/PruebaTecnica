namespace API.Controllers.Consultas
{
    using API.Models.Consultas;
    using Base.IC.Clases;
    using Base.IC.DTO.Consultas.Compra;
    using Base.Negocio.Clases.BL.Consultas;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    [RoutePrefix("api/ReportesCompras")]
    public class ReportesComprasController : ApiController
    {
        private ReporteCompraBL reporteCompra;
        private ReporteCompraDetalleBL reporteCompraDetalle;

        public ReportesComprasController()
        {
            this.reporteCompra = new ReporteCompraBL();
            this.reporteCompraDetalle = new ReporteCompraDetalleBL();
        }

        [HttpPost]
        [Route("ReporteCompra")]
        public Respuesta<ReporteCompra> ReporteCompra(ReporteCompraFiltro reporteCompraFiltro)
        {
            return MapeadorReporteCompra(reporteCompra.ReporteCompra(MapeadorReporteCompraFiltro(reporteCompraFiltro)));
        }

        [HttpPost]
        [Route("ReporteCompraDetalle")]
        public Respuesta<ReporteCompraDetalle> ReporteCompraDetalle(ReporteCompraDetalleFiltro reporteCompraDetalleFiltro)
        {
            return MapeadorReporteCompraDetalle(reporteCompraDetalle.ReporteCompraDetalle(MapeadorReporteCompraDetalleFiltro(reporteCompraDetalleFiltro)));
        }

        public IReporteCompraFiltroDTO MapeadorReporteCompraFiltro(ReporteCompraFiltro reporteCompraFiltro)
        {
            List<IReporteCompraFiltroDTO> reporteCompraFiltroDTOs = new List<IReporteCompraFiltroDTO>();

            reporteCompraFiltroDTOs.Add(reporteCompraFiltro);

            return reporteCompraFiltroDTOs.First();
        }

        public IReporteCompraDetalleFiltroDTO MapeadorReporteCompraDetalleFiltro(ReporteCompraDetalleFiltro reporteCompraDetalleFiltro)
        {
            List<IReporteCompraDetalleFiltroDTO> reporteCompraDetalleFiltros = new List<IReporteCompraDetalleFiltroDTO>();

            reporteCompraDetalleFiltros.Add(reporteCompraDetalleFiltro);

            return reporteCompraDetalleFiltros.First();
        }

        public Respuesta<ReporteCompra> MapeadorReporteCompra(Respuesta<IReporteCompraDTO> respuesta)
        {
            List<ReporteCompra> entidades = new List<ReporteCompra>();

            foreach (IReporteCompraDTO item in respuesta.Entidades)
            {
                ReporteCompra ReporteCompra = new ReporteCompra
                {
                    CantidadComic = item.CantidadComic,
                    Celular = item.Celular,
                    Comprador = item.Comprador,
                    Direccion = item.Direccion,
                    FechaCompra = item.FechaCompra,
                    NumeroDocumento = item.NumeroDocumento,
                    Orden = item.Orden,
                    TotalCompra = item.TotalCompra
                };
                entidades.Add(ReporteCompra);
            }

            Respuesta<ReporteCompra> mapeador = new Respuesta<ReporteCompra>
            {
                Entidades = entidades,
                Mensajes = respuesta.Mensajes,
                Resultado = respuesta.Resultado,
                TipoNotificacion = respuesta.TipoNotificacion
            };

            return mapeador;
        }

        public Respuesta<ReporteCompraDetalle> MapeadorReporteCompraDetalle(Respuesta<IReporteCompraDetalleDTO> respuesta)
        {
            List<ReporteCompraDetalle> entidades = new List<ReporteCompraDetalle>();

            foreach (IReporteCompraDetalleDTO item in respuesta.Entidades)
            {
                ReporteCompraDetalle ReporteCompraDetalle = new ReporteCompraDetalle
                {
                    CantidadComic = item.CantidadComic,
                    NombreComic = item.NombreComic,
                    ValorComic = item.ValorComic
                };
                entidades.Add(ReporteCompraDetalle);
            }

            Respuesta<ReporteCompraDetalle> mapeador = new Respuesta<ReporteCompraDetalle>
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