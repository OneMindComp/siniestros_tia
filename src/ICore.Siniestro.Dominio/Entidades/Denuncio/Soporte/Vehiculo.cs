namespace ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte
{
    public class Vehiculo
    {
        public string Patente { get; private set; } = default!;
        public string NumeroMotor { get; private set; } = default!;

        private Vehiculo() { }

        private Vehiculo(string patente, string numeroMotor)
        {
            Patente = patente;
            NumeroMotor = numeroMotor;
        }

        public static Vehiculo Crear(string patente, string numeroMotor)
        {
            return new Vehiculo(patente, numeroMotor);
        }
    }
}
