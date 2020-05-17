namespace Base.IC.DTO.EntidadesRepositorio
{
    public interface IUsuarioDTO
    {
        int Id { get; set; }
        string Nombre { get; set; }
        int NumeroDocumento { get; set; }
        string Direccion { get; set; }
        int Celular { get; set; }
        int TipoDocumento { get; set; }
    }
}