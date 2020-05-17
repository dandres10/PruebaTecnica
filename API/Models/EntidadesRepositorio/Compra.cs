namespace API.Models.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;
    using System;

    public class Compra : ICompraDTO
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string Pedido { get; set; }
    }
}