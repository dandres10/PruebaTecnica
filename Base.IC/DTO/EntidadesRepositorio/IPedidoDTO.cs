namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IPedidoDTO
    {
        string Guid { get; set; }
        int Comic { get; set; }
        int Usuario { get; set; }
        double Valor { get; set; }
    }
}