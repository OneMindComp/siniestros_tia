namespace ICore.Siniestro.Dominio.Entidades.Falabella
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

        //---------------------- Falabella --------------------------------//

        /// <summary>
        /// Sub numero de riesgo.
        /// </summary>
        public string? SubNumeroRiesgo { get; private set; }

        /// <summary>
        /// Archivado por.
        /// </summary>
        public string? ArchivadoPor { get; private set; }


        private Riesgo() { }

        private Riesgo(
            int? numero,
            string? codigo,
            string? descripcion,
            List<string>? especificaciones,
            string? subNumeroRiesgo,
            string? archivadoPor
        )
        {
            Numero = numero;
            Codigo = codigo;
            Descripcion = descripcion;
            Especificaciones = especificaciones;
            SubNumeroRiesgo = subNumeroRiesgo;
            ArchivadoPor = archivadoPor;
        }

        public static Riesgo Crear(
            int? numero,
            string? codigo,
            string? descripcion,
            List<string>? especificaciones,
            string? subNumeroRiesgo,
            string? archivadoPor
            )
        {
            return new Riesgo(
                numero,
                codigo,
                descripcion,
                especificaciones,
                subNumeroRiesgo,
                archivadoPor
            );
        }
    }
}
