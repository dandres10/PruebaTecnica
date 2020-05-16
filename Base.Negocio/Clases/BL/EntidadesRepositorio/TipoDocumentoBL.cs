namespace Base.Negocio.Clases.BL.EntidadesRepositorio
{
    using Base.Datos.Clases.DAL.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public class TipoDocumentoBL : ITipoDocumentoAccion
    {

        Respuesta<ITipoDocumentoDTO> Respuesta;
        TipoDocumentoDAL tipoDocumentoDAL;

        public TipoDocumentoBL()
        {
            this.Respuesta = new Respuesta<ITipoDocumentoDTO>();
            this.tipoDocumentoDAL = new TipoDocumentoDAL();

        }


        public Respuesta<ITipoDocumentoDTO> GuadarTipoDocumento(ITipoDocumentoDTO tipoDocumento)
        {
            return tipoDocumentoDAL.GuadarTipoDocumento(tipoDocumento);
        }
    }
}