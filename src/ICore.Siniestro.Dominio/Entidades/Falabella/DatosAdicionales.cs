namespace ICore.Siniestro.Dominio.Entidades.Falabella
{
    /// <summary>
    /// Datos adicionales que se envian a FraudKeeper.
    /// </summary>
    public class DatosAdicionales
    {
        /// <summary>
        /// Codigo del dato adicional.
        /// </summary>
        public string? Codigo { get; private set; }

        /// <summary>
        /// Nombre del dato adicional.
        /// </summary>
        public string? Nombre { get; private set; }

        /// <summary>
        /// Plugin utilizado.
        /// </summary>
        public string? Plugin { get; private set; }

        /// <summary>
        /// Valor del dato adicional.
        /// </summary>
        public string? Valor { get; private set; }

        /// <summary>
        /// Version
        /// </summary>
        public int? Version { get; private set; }

        private DatosAdicionales() { }

        private DatosAdicionales(
            string? codigo,
            string? nombre,
            string? plugin,
            string? valorDato,
            int? version
            )
        {
            Codigo = codigo;
            Nombre = nombre;
            Plugin = plugin;
            Valor = valorDato;
            Version = version;
        }

        public static DatosAdicionales Crear(
            string? codigo,
            string? nombre,
            string? plugin,
            string? valorDato,
            int? version
            )
        {
            return new DatosAdicionales(
                codigo,
                nombre,
                plugin,
                valorDato,
                version
            );
        }
    }
}
