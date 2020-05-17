namespace Base.IC.Acciones.Consultas.Compra
{
    using Base.IC.Clases;
    using Base.IC.DTO.Consultas.Compra;

    public interface IReporteCompraAccion
    {
        Respuesta<IReporteCompraDTO> ReporteCompra(IReporteCompraFiltroDTO reporteCompraFiltro);
    }
}