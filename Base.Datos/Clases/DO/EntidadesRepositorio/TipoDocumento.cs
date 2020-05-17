namespace Base.Datos.Clases.DO.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class TipoDocumento : ITipoDocumentoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
    }
}