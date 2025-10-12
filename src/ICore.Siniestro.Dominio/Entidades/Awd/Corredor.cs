namespace ICore.Siniestro.Dominio.Entidades.Awd
{
    public class Corredor
    {
        public string Id { get; private set; } = default!;
        public string Nombre { get; private set; } = default!;

        private Corredor() { }
        private Corredor(
            string? id,
            string? nombre
            )
        {
            Id = id!;
            Nombre = nombre!;
        }

        public static Corredor Crear(
            string? id,
            string? nombre
            )
        {
            return new Corredor(
                id,
                nombre
            );
        }
    }
}
