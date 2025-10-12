namespace ICore.Siniestro.Dominio.Entidades
{
    public class Vehiculo : Entidad<long>
    {
        public string Patente { get; private set; } = default!;

        private Vehiculo()
        {
        }

        private Vehiculo(string patente)
        {
            Patente = patente;
        }

        public static Vehiculo Crear(string patente)
        {
            return new Vehiculo(patente);
        }
    }
}
