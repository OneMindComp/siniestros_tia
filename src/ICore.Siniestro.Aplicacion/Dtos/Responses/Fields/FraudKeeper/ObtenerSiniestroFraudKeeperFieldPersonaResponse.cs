using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper
{
    /// <summary>
    /// Campo persona para Response de obtener siniestro fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperFieldPersonaResponse : IMapFrom<Persona>
    {
        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string? Nombre { get; set; }

        /// <summary>
        /// RUT de la persona.
        /// </summary>
        public string? Rut { get; set; }

        /// <summary>
        /// Direccion de la persona.
        /// </summary>
        public string? Direccion { get; set; }

        /// <summary>
        /// Ciudad de la persona.
        /// </summary>
        public string? Ciudad { get; set; }

        /// <summary>
        /// Estado de la persona.
        /// </summary>
        public string? Estado { get; set; }

        /// <summary>
        /// Pais de la persona.
        /// </summary>
        public string? Pais { get; set; }

        /// <summary>
        /// Tipo de persona C: Empresa P: Persona.
        /// </summary>
        public string? TipoPersona { get; set; }

        /// <summary>
        /// Nombre a desplegar.
        /// </summary>
        public string? NombreADesplegar { get; set; }

        /// <summary>
        /// Fecha desde cuando es cliente.
        /// </summary>
        public DateTime? ClienteDesde { get; set; }
    }
}
