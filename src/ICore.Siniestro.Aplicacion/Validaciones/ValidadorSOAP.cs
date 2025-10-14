using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;

namespace ICore.Siniestro.Aplicacion.Validaciones
{
    /// <summary>
    /// Validador para denuncios SOAP
    /// </summary>
    public class ValidadorSOAP : ValidadorBase
    {
        /// <summary>
        /// valida los campos especificos para denuncios SOAP
        /// </summary>
        /// <param name="denuncio"></param>
        /// <param name="errores"></param>
        protected override void ValidarEspecifico(DenuncioSiniestroRequest denuncio, List<string> errores)
        {
            if (denuncio is not DenuncioSoapRequest soap) return;

            if (soap.Vehiculo == null || string.IsNullOrEmpty(soap.Vehiculo.Patente))
                errores.Add("Vehiculo es requerido para denuncios SOAP");

            if (soap.Conductor == null || string.IsNullOrEmpty(soap.Conductor.Rut))
                errores.Add("Conductor es requerido para denuncios SOAP");

            if (soap.Poliza == null || string.IsNullOrEmpty(soap.Poliza.NumeroPoliza))
                errores.Add("Poliza es requerida para denuncios SOAP");

            if (soap.Denunciante == null || string.IsNullOrEmpty(soap.Denunciante.Telefono))
                errores.Add("Denunciante es requerido para denuncios SOAP");

            if (string.IsNullOrEmpty(soap.Siniestro.Ubicacion))
                errores.Add("Ubicacion es requerida para denuncios SOAP");
        }
    }
}
