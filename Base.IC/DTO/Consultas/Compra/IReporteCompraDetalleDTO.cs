namespace Base.IC.DTO.Consultas.Compra
{
    public interface IReporteCompraDetalleDTO
    {
        string NombreComic { get; set; }
        int CantidadComic { get; set; }
        double ValorComic { get; set; }
    }
}