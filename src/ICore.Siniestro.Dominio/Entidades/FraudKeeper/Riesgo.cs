namespace ICore.Siniestro.Dominio.Entidades.FraudKeeper
{
    /// <summary>
    /// Riesgo.
    /// </summary>
    public class Riesgo : Entidad<long>
    {
        /// <summary>
        /// Numero de riesgo.
        /// </summary>
        public int? Numero { get; private set; }

        /// <summary>
        /// Codigo de riesgo.
        /// </summary>
        public string? Codigo { get; private set; }

        /// <summary>
        /// Descripcion del riesgo.
        /// </summary>
        public string? Descripcion { get; private set; }

        /// <summary>
        /// Especificaciones del riesgo.
        /// </summary>
        public List<string>? Especificaciones { get; private set; }


        private Riesgo() { }

        private Riesgo(
            int? numero,
            string? codigo,
            string? descripcion,
            List<string>? especificaciones
        )
        {
            Numero = numero;
            Codigo = codigo;
            Descripcion = descripcion;
            Especificaciones = especificaciones;
        }

        public static Riesgo Crear(
            int? numero,
            string? codigo,
            string? descripcion,
            List<string>? especificaciones
            )
        {
            return new Riesgo(
                numero,
                codigo,
                descripcion,
                especificaciones
            );
        }
    }
}
