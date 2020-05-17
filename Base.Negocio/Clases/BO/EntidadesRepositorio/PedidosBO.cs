namespace Base.Negocio.Clases.BO.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class PedidosBO : IPedidoDTO
    {
        public string Guid { get; set; }
        public int Comic { get; set; }
        public int Usuario { get; set; }
        public double Valor { get; set; }
    }
}