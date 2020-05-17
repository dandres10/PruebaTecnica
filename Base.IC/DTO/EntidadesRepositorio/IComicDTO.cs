namespace Base.IC.DTO.EntidadesRepositorio
{
    using System;

    public interface IComicDTO
    {
        int Id { get; set; }
        string Nombre { get; set; }
        string Autor { get; set; }
        DateTime Fecha { get; set; }
    }
}