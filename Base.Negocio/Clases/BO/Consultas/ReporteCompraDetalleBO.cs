namespace Base.Negocio.Clases.BO.Consultas
{
    using Base.IC.DTO.Consultas.Compra;

    public class ReporteCompraDetalleBO : IReporteCompraDetalleDTO
    {
        public string NombreComic { get; set; }
        public int CantidadComic { get; set; }
        public double ValorComic { get; set; }
    }
}