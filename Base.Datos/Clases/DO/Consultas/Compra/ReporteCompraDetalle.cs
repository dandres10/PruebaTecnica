namespace Base.Datos.Clases.DO.Consultas
{
    using Base.IC.DTO.Consultas.Compra;

    public class ReporteCompraDetalle : IReporteCompraDetalleDTO
    {
        public string NombreComic { get; set; }
        public int CantidadComic { get; set; }
        public double ValorComic { get; set; }
    }
}