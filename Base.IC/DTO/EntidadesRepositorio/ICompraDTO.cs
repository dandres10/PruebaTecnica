namespace Base.IC.DTO.EntidadesRepositorio
{
    using System;

    public interface ICompraDTO
    {
        int Id { get; set; }
        DateTime Fecha { get; set; }
        double Total { get; set; }
        string Pedido { get; set; }
    }
}