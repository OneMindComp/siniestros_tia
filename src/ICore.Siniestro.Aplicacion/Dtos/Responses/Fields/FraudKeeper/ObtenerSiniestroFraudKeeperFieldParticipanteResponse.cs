using ICore.Siniestro.Aplicacion.Mapeadores;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper
{
    /// <summary>
    /// Campo participante para Response de obtener siniestro fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperFieldParticipanteResponse : IMapFrom<Participante>
    {
        /// <summary>
        /// Rol de la persona: Demandante, Asegurado, Afectado, Corredor, Liquidador.
        /// </summary>
        public List<string>? Roles { get; set; }

        /// <summary>
        /// Id de ejecutivo (Liquidador, Corredor).
        /// </summary>
        public string? IdEjecutivo { get; set; }

        /// <summary>
        /// persona.
        /// </summary>
        public ObtenerSiniestroFraudKeeperFieldPersonaResponse? Persona { get; set; }
    }
}
