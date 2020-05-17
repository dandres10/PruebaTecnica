namespace Base.Datos.Clases.DO.Consultas
{
    using Base.IC.DTO.Consultas.Compra;

    public class ReporteCompraDetalleFiltro : IReporteCompraDetalleFiltroDTO
    {
        public int NumeroDocumento { get; set; }
        public string GuidPedido { get; set; }
    }
}