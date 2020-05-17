namespace Base.IC.DTO.Consultas.Compra
{
    public interface IReporteCompraDetalleFiltroDTO
    {
        int NumeroDocumento { get; set; }

        string GuidPedido { get; set; }
    }
}