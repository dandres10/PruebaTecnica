namespace API.Models.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;

    public class Usuario : IUsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int NumeroDocumento { get; set; }
        public string Direccion { get; set; }
        public int Celular { get; set; }
        public int TipoDocumento { get; set; }
    }
}