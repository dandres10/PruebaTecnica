namespace Base.IC.Acciones.EntidadesRepositorio
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface ICompraAccion
    {
        Respuesta<ICompraDTO> GuadarCompra(ICompraDTO comic);
    }
}