namespace Base.Negocio.Clases.BL.EntidadesRepositorio
{
    using Base.Datos.Clases.DAL.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public class ComicBL : IComicAccion
    {
        private ComicDAL ComicDAL;

        public ComicBL()
        {
            this.ComicDAL = new ComicDAL();
        }

        public Respuesta<IComicDTO> ConsultarComic(IComicDTO comic)
        {
            return ComicDAL.ConsultarComic(comic);
        }

        public Respuesta<IComicDTO> GuadarComic(IComicDTO comic)
        {
            return ComicDAL.GuadarComic(comic);
        }
    }
}