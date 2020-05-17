namespace Base.IC.Clases
{
    using System.Collections.Generic;

    public class Respuesta<T>
    {
        public Respuesta()
        {
            Entidades = new List<T>();
            Mensajes = new List<string>();
        }

        public bool Resultado { get; set; }
        public List<T> Entidades { get; set; }
        public List<string> Mensajes { get; set; }
        public int TipoNotificacion { get; set; }
    }
}