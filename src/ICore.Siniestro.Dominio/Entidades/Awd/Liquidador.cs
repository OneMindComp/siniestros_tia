namespace ICore.Siniestro.Dominio.Entidades.Awd
{
    public class Liquidador
    {
        public string Id { get; private set; } = default!;
        public string Nombre { get; private set; } = default!;

        private Liquidador() { }
        private Liquidador(
            string? id,
            string? nombre
            )
        {
            Id = id!;
            Nombre = nombre!;
        }

        public static Liquidador Crear(
            string? id,
            string? nombre
            )
        {
            return new Liquidador(
                id,
                nombre
            );
        }
    }
}
