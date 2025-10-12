using ICore.Siniestro.Comun.Helpers;
using Sbins.Comunes.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICore.Siniestro.Comun.Extensions
{
    public static class ExceptionExtension
    {
        public static Exception GetRefinedException(this Exception baseException, string origen)
        {
            Type typeBase = baseException.GetType();
            if (typeBase != typeof(InfraestructureException) && typeBase != typeof(NotFoundException))
            {

                return new InfraestructureException(MessageHelper.ConstruirMensajeErrorGenerico(origen, baseException.Message));
            }

            return baseException;
        }
    }
}
