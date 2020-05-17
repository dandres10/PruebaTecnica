namespace API.Models.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class Pedido : IPedidoDTO
    {
        public string Guid { get; set; }
        public int Comic { get; set; }
        public int Usuario { get; set; }
        public double Valor { get; set; }
    }
}