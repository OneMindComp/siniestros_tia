namespace ICore.Siniestro.Dominio.Entidades.Awd
{
    public class Asegurado
    {
        public string Rut { get; private set; } = default!;
        public string Nombre { get; private set; } = default!;

        private Asegurado() { }
        private Asegurado(
            string? rut,
            string? nombre
            )
        {
            Rut = rut!;
            Nombre = nombre!;
        }

        public static Asegurado Crear(
            string? rut,
            string? nombre
            )
        {
            return new Asegurado(
                rut,
                nombre
            );
        }
    }
}
