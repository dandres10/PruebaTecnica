namespace Base.Negocio.Clases.BL.Consultas
{
    using Base.Datos.Clases.DAL.Consultas.Compra;
    using Base.IC.Acciones.Consultas.Compra;
    using Base.IC.Clases;
    using Base.IC.DTO.Consultas.Compra;
    using System;

    public class ReporteCompraDetalleBL : IReporteCompraDetalleAccion
    {
        private ReporteCompraDetalleDAL reporteCompraDetalleDAL;

        public ReporteCompraDetalleBL()
        {
            this.reporteCompraDetalleDAL = new ReporteCompraDetalleDAL();
        }

        public Respuesta<IReporteCompraDetalleDTO> ReporteCompraDetalle(IReporteCompraDetalleFiltroDTO reporteCompraDetalleFiltro)
        {
            return reporteCompraDetalleDAL.ReporteCompraDetalle(reporteCompraDetalleFiltro);
        }
    }
}