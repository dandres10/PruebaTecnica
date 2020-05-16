namespace Base.IC.Acciones.EntidadesRepositorio
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface ITipoDocumentoAccion
    {
        Respuesta<ITipoDocumentoDTO> GuadarTipoDocumento(ITipoDocumentoDTO tipoDocumento);
    }
}