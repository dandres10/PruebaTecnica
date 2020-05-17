namespace Base.IC.Acciones.EntidadesRepositorio
{
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public interface IUsuarioAccion
    {
        Respuesta<IUsuarioDTO> GuadarUsuario(IUsuarioDTO usuario);
        Respuesta<IUsuarioDTO> ConsultarUsuario(IUsuarioDTO usuario);
    }
}