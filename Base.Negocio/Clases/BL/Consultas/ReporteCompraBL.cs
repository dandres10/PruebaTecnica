namespace Base.Negocio.Clases.BL.Consultas
{
    using Base.Datos.Clases.DAL.Consultas.Compra;
    using Base.IC.Acciones.Consultas.Compra;
    using Base.IC.Clases;
    using Base.IC.DTO.Consultas.Compra;

    public class ReporteCompraBL : IReporteCompraAccion
    {
        private ReporteCompraDAL reporteCompraDAL;

        public ReporteCompraBL()
        {
            this.reporteCompraDAL = new ReporteCompraDAL();
        }

        public Respuesta<IReporteCompraDTO> ReporteCompra(IReporteCompraFiltroDTO reporteCompraFiltro)
        {
            return reporteCompraDAL.ReporteCompra(reporteCompraFiltro);
        }
    }
}