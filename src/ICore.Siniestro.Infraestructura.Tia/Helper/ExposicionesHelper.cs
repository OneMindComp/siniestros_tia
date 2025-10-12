using ICore.Siniestro.Dominio.Entidades.FraudKeeper;

namespace ICore.Siniestro.Infraestructura.Tia.Helper
{
    public static class ExposicionesHelper
    {
        public static Exposicion CrearExposicion(
            List<string>? modelos,
            List<string>? datosAdicionales,
            List<string>? vehiculos,
            List<Riesgo>? riesgo,
            string? descripcionCobertura,
            string? codigoCobertura,
            string? monedaCobertura,
            string? actualMontoAsegurado,
            string? montoAseguradoOriginal,
            decimal? reservas,
            int? pagos,
            int? reservasMonedaLocal,
            int? pagosMonedaLocal,
            bool? firstParty,
            List<string>? contactosRelacionados
            )
        {
            return Exposicion.Crear(
                modelos,
                datosAdicionales,
                vehiculos,
                riesgo,
                descripcionCobertura,
                codigoCobertura,
                monedaCobertura,
                actualMontoAsegurado,
                montoAseguradoOriginal,
                reservas,
                pagos,
                reservasMonedaLocal,
                pagosMonedaLocal,
                firstParty,
                contactosRelacionados
                );
        }
    }
}
