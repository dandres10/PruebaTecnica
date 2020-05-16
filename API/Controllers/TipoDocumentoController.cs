namespace API.Controllers
{
    using API.Models.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;
    using Base.Negocio.Clases.BL.EntidadesRepositorio;
    using System.Collections.Generic;
    using System.Web.Http;

    [RoutePrefix("api/TipoDocumento")]
    public class TipoDocumentoController : ApiController, ITipoDocumentoAccion
    {
        private TipoDocumentoBL negocioTipoDocumentoBL;

        public TipoDocumentoController()
        {
            this.negocioTipoDocumentoBL = new TipoDocumentoBL();
        }

        [HttpPost]
        [Route("GuadarTipoDocumento")]
        public Respuesta<TipoDocumento> GenerarAlmacenamientoOperacion(TipoDocumento tipoDocumento)
        {
            Respuesta<ITipoDocumentoDTO> respuesta = GuadarTipoDocumento(tipoDocumento);

            return Mapeador(respuesta);
        }

        public Respuesta<ITipoDocumentoDTO> GuadarTipoDocumento(ITipoDocumentoDTO tipoDocumento)
        {
            return negocioTipoDocumentoBL.GuadarTipoDocumento(tipoDocumento);
        }

        public Respuesta<TipoDocumento> Mapeador(Respuesta<ITipoDocumentoDTO> respuesta)
        {
            List<TipoDocumento> entidades = new List<TipoDocumento>();

            foreach (ITipoDocumentoDTO item in respuesta.Entidades)
            {
                TipoDocumento tipoDocumento = new TipoDocumento
                {
                    Codigo = item.Codigo,
                    Nombre = item.Nombre
                };
                entidades.Add(tipoDocumento);
            }

            Respuesta<TipoDocumento> mapeador = new Respuesta<TipoDocumento>
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