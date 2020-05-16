namespace API.Models.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class TipoDocumento : ITipoDocumentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}