namespace ICore.Siniestro.Dominio.Entidades
{
    public class Persona : Entidad<long>
    {
        public string NumeroDocumento { get; private set; } = default!;
        public string Nombre { get; private set; } = default!;

        protected Persona()
        {
        }

        protected Persona(string numeroDocumento, string nombre)
        {
            NumeroDocumento = numeroDocumento;
            Nombre = nombre;
        }
    }
}
