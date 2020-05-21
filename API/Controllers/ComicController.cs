namespace API.Controllers
{
    using API.Models.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.Configuracion;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL.EntidadesRepositorio;
    using System.Collections.Generic;
    using System.Web.Http;
    using System.Web.Http.Cors;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Comic")]
    public class ComicController : ApiController
    {
        private ComicBL comicBL;

        public ComicController()
        {
            this.comicBL = new ComicBL();
        }

        [HttpGet]
        [Route("ConsultarComic")]
        public Respuesta<Comic> ConsultarComic(Comic comic)
        {
            return Mapeador(comicBL.ConsultarComic(comic)); 
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [Route("GuadarComic")]
        public Respuesta<Comic> GuadarComic(Comic comic)
        {
            return Mapeador(comicBL.GuadarComic(comic));
        }

        public Respuesta<Comic> Mapeador(Respuesta<IComicDTO> respuesta)
        {
            List<Comic> entidades = new List<Comic>();

            foreach (IComicDTO item in respuesta.Entidades)
            {
                Comic Comic = new Comic
                {
                    Nombre = item.Nombre,
                    Autor = item.Autor,
                    Fecha = item.Fecha,
                    Id = item.Id
                };
                entidades.Add(Comic);
            }

            Respuesta<Comic> mapeador = new Respuesta<Comic>
            {
                Entidades = entidades,
                Mensajes = respuesta.Mensajes,
                Resultado = respuesta.Resultado,
                TipoNotificacion = respuesta.TipoNotificacion
            };

            return mapeador;
        }
    }
}