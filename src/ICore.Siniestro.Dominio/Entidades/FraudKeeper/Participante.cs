using ICore.Siniestro.Dominio.Entidades;

namespace ICore.Siniestro.Dominio.Entidades.FraudKeeper
{
    /// <summary>
    /// Participacion de una persona dentro del siniestro.
    /// </summary>
    public class Participante
    {
        /// <summary>
        /// Rol de la persona: Demandante, Asegurado, Afectado, Corredor, Liquidador.
        /// </summary>
        public List<string>? Roles { get; private set; }

        /// <summary>
        /// Id de ejecutivo (Liquidador, Corredor).
        /// </summary>
        public string? IdEjecutivo { get; private set; }

        /// <summary>
        /// Persona.
        /// </summary>
        public Persona? Persona { get; private set; }

        private Participante() { }

        private Participante(
            List<string>? rol,
            Persona? persona,
            string? idEjecutivo
            )
        {
            Roles = rol;
            Persona = persona;
            IdEjecutivo = idEjecutivo;
        }

        public static Participante Crear(
            List<string>? rol,
            Persona? persona,
            string? idEjecutivo
            )
        {
            return new Participante(
                rol,
                persona,
                idEjecutivo);
        }
    }
}
