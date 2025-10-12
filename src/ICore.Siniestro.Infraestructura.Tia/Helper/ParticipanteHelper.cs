using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Infraestructura.Tia.Helper
{
    public class ParticipanteHelper
    {
        public static Participante CrearParticipante(List<string>? roles, Persona? persona, string? idEjecutivo)
        {
            return Participante.Crear(roles, persona, idEjecutivo);
        }
    }
}
