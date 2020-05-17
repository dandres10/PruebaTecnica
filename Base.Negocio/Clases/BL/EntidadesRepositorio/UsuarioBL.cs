namespace Base.Negocio.Clases.BL.EntidadesRepositorio
{
    using Base.Datos.Clases.DAL.EntidadesRepositorio;
    using Base.IC.Acciones.EntidadesRepositorio;
    using Base.IC.Clases;
    using Base.IC.DTO.EntidadesRepositorio;

    public class UsuarioBL : IUsuarioAccion
    {
        private UsuarioDAL usuarioDAL;

        public UsuarioBL()
        {
            this.usuarioDAL = new UsuarioDAL();
        }

        public Respuesta<IUsuarioDTO> ConsultarUsuario(IUsuarioDTO usuario)
        {
            return usuarioDAL.ConsultarUsuario(usuario);
        }

        public Respuesta<IUsuarioDTO> GuadarUsuario(IUsuarioDTO usuario)
        {
            return usuarioDAL.GuadarUsuario(usuario);
        }
    }
}