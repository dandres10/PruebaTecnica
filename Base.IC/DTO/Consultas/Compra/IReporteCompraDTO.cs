namespace Base.IC.DTO.Consultas.Compra
{
    using System;

    public interface IReporteCompraDTO
    {
        string Orden { get; set; }

        string Comprador { get; set; }
        int NumeroDocumento { get; set; }
        string Direccion { get; set; }
        int Celular { get; set; }
        DateTime FechaCompra { get; set; }
        int CantidadComic { get; set; }
        double TotalCompra { get; set; }
    }
}