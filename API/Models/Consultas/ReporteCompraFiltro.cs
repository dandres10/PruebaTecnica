﻿namespace API.Models.Consultas
{
    using Base.IC.DTO.Consultas.Compra;

    public class ReporteCompraFiltro : IReporteCompraFiltroDTO
    {
        public int NumeroDocumento { get; set; }
        public string GuidPedido { get; set; }
    }
}