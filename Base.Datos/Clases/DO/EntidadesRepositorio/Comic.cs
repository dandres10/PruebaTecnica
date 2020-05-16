namespace Base.Datos.Clases.DO.EntidadesRepositorio
{
    using Base.IC.DTO.EntidadesRepositorio;
    using System;

    public class Comic : IComicDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public DateTime Fecha { get; set; }
    }
}