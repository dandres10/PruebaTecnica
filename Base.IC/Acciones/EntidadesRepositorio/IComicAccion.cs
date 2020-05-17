namespace Base.IC.Acciones.EntidadesRepositorio
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface IComicAccion
    {
        Respuesta<IComicDTO> GuadarComic(IComicDTO comic);

        Respuesta<IComicDTO> ConsultarComic(IComicDTO comic);
    }
}