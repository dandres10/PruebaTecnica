namespace Base.Negocio.Clases.BO.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class TipoDocumentoBO : ITipoDocumentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}