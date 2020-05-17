namespace Base.Negocio.Clases.BL.EntidadesRepositorio
{
    using Base.Datos.Clases.DAL.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public class CompraBL : ICompraAccion
    {
        private CompraDAL compraDAL;

        public CompraBL()
        {
            this.compraDAL = new CompraDAL();
        }

        public Respuesta<ICompraDTO> GuadarCompra(ICompraDTO comic)
        {
            return compraDAL.GuadarCompra(comic);
        }
    }
}