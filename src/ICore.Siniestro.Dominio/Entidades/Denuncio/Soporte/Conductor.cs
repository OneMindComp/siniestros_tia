namespace ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte
{
    public class Conductor
    {
        public string NombreCompleto { get; private set; } = default!;
        public string Rut { get; private set; } = default!;

        private Conductor() { }

        private Conductor(string nombreCompleto, string rut)
        {
            NombreCompleto = nombreCompleto;
            Rut = rut;
        }

        public static Conductor Crear(string nombreCompleto, string rut)
        {
            return new Conductor(nombreCompleto, rut);
        }
    }
}
