namespace API.Controllers
{
    using API.Models.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL.EntidadesRepositorio;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/Usuario")]
    public class UsuarioController : ApiController
    {
        private UsuarioBL usuarioNegocio;

        public UsuarioController()
        {
            this.usuarioNegocio = new UsuarioBL();
        }

        [HttpPost]
        [Route("GuadarUsuario")]
        public Respuesta<Usuario> GuadarUsuario(Usuario usuario)
        {
            return Mapeador(usuarioNegocio.GuadarUsuario(usuario));
        }

        [HttpGet]
        [Route("ConsultarUsuario")]
        public Respuesta<Usuario> ConsultarUsuario(Usuario usuario)
        {
            return Mapeador(usuarioNegocio.ConsultarUsuario(usuario));
        }

        public Respuesta<Usuario> Mapeador(Respuesta<IUsuarioDTO> respuesta)
        {
            List<Usuario> entidades = new List<Usuario>();

            foreach (IUsuarioDTO item in respuesta.Entidades)
            {
                Usuario usuario = new Usuario
                {
                    Nombre = item.Nombre,
                    Celular = item.Celular,
                    Direccion = item.Direccion,
                    NumeroDocumento = item.NumeroDocumento,
                    Id = item.Id,
                    TipoDocumento = item.TipoDocumento
                };
                entidades.Add(usuario);
            }

            Respuesta<Usuario> mapeador = new Respuesta<Usuario>
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