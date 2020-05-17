namespace Base.Datos.Clases.DO.Consultas
{
    using Base.IC.DTO.Consultas.Compra;
    using System;

    public class ReporteCompra : IReporteCompraDTO
    {
        public string Orden { get; set; }
        public string Comprador { get; set; }
        public int NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public int Celular { get; set; }
        public DateTime FechaCompra { get; set; }
        public int CantidadComic { get; set; }
        public double TotalCompra { get; set; }
    }
}