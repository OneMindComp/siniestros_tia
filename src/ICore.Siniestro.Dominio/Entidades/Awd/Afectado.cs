namespace ICore.Siniestro.Dominio.Entidades.Awd
{
    public class Afectado
    {
        public string Rut { get; private set; } = default!;
        public string Nombre { get; private set; } = default!;

        private Afectado() { }

        private Afectado(
            string? rut,
            string? nombre
            )
        {
            Rut = rut!;
            Nombre = nombre!;
        }

        public static Afectado Crear(
            string? rut,
            string? nombre
            )
        {
            return new Afectado(
                rut,
                nombre
            );
        }
    }
}
