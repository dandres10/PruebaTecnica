namespace Base.IC.Acciones.Consultas.Compra
{
    using Base.IC.Clases;
    using Base.IC.DTO.Consultas.Compra;

    public interface IReporteCompraDetalleAccion
    {
        Respuesta<IReporteCompraDetalleDTO> ReporteCompraDetalle(IReporteCompraDetalleFiltroDTO reporteCompraDetalleFiltro);
    }
}