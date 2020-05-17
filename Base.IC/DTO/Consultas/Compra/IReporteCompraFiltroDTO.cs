namespace Base.IC.DTO.Consultas.Compra
{
    public interface IReporteCompraFiltroDTO
    {
        int NumeroDocumento { get; set; }

        string GuidPedido { get; set; }
    }
}