namespace ICore.Siniestro.Dominio.Entidades.Soap
{
    public class Lesionado : Persona
    {
        private Lesionado() : base() { }

        private Lesionado(string numeroDocumento, string nombre) : base(numeroDocumento, nombre)
        {
        }

        public static Lesionado Crear(string numeroDocumento, string nombre)
        {
            return new Lesionado(numeroDocumento, nombre);
        }
    }
}
