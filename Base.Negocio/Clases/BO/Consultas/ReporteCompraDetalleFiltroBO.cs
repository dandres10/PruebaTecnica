namespace Base.Negocio.Clases.BO.Consultas
{
    using Base.IC.DTO.Consultas.Compra;

    public class ReporteCompraDetalleFiltroBO : IReporteCompraDetalleFiltroDTO
    {
        public int NumeroDocumento { get; set; }
        public string GuidPedido { get; set; }
    }
}