namespace ICore.Siniestro.Dominio.Entidades.FraudKeeper
{
    /// <summary>
    /// Persona.
    /// </summary>
    public class Persona : Entidad<long>
    {
        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string? Nombre { get; private set; }

        /// <summary>
        /// RUT de la persona.
        /// </summary>
        public string? Rut { get; private set; }

        /// <summary>
        /// Direccion de la persona.
        /// </summary>
        public string? Direccion { get; private set; }

        /// <summary>
        /// Ciudad de la persona.
        /// </summary>
        public string? Ciudad { get; private set; }

        /// <summary>
        /// Estado de la persona.
        /// </summary>
        public string? Estado { get; private set; }

        /// <summary>
        /// Pais de la persona.
        /// </summary>
        public string? Pais { get; private set; }

        /// <summary>
        /// Tipo de persona C: Empresa P: Persona.
        /// </summary>
        public string? TipoPersona { get; private set; }

        /// <summary>
        /// Nombre a desplegar.
        /// </summary>
        public string? NombreADesplegar { get; private set; }

        /// <summary>
        /// Fecha desde cuando es cliente.
        /// </summary>
        public DateTime? ClienteDesde { get; private set; }


        private Persona() { }

        private Persona(
            string? nombre,
            string? rut,
            string? direccion,
            string? ciudad,
            string? estado,
            string? pais,
            string? tipoPersona,
            string? nombreADesplegar,
            DateTime? clienteDesde
            )
        {
            Nombre = nombre;
            Rut = rut;
            Direccion = direccion;
            Ciudad = ciudad;
            Estado = estado;
            Pais = pais;
            TipoPersona = tipoPersona;
            NombreADesplegar = nombreADesplegar;
            ClienteDesde = clienteDesde;
        }

        public static Persona Crear(
            string? nombre,
            string? rut,
            string? direccion,
            string? ciudad,
            string? estado,
            string? pais,
            string? tipoPersona,
            string? nombreADesplegar,
            DateTime? clienteDesde
            )
        {
            return new Persona(
                nombre,
                rut,
                direccion,
                ciudad,
                estado,
                pais,
                tipoPersona,
                nombreADesplegar,
                clienteDesde
                );
        }
    }
}
