namespace ICore.Siniestro.Dominio.Entidades.Soap
{
    public class Contratante : Persona
    {
        private Contratante() : base() { }

        private Contratante(string numeroDocumento, string nombre) : base(numeroDocumento, nombre)
        {
        }

        public static Contratante Crear(string numeroDocumento, string nombre)
        {
            return new Contratante(numeroDocumento, nombre);
        }
    }
}
