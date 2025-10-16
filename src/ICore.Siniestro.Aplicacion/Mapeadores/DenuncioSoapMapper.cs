using ICore.Siniestro.Aplicacion.Dtos.Requests.Denuncio;
using ICore.Siniestro.Dominio.Entidades.Denuncio;
using ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte;

namespace ICore.Siniestro.Aplicacion.Mapeadores
{
    /// <summary>
    /// Clase para mapear DenuncioSoapRequest a DenuncioSoap
    /// </summary>
    public static class DenuncioSoapMapper
    {
        /// <summary>
        /// Mapea un DenuncioSoapRequest a una entidad DenuncioSoap usando los metodos Crear de cada clase
        /// </summary>
        /// <param name="request">Request con los datos del denuncio</param>
        /// <returns>Entidad de dominio DenuncioSoap</returns>
        public static DenuncioSoap MapearDesdeRequest(DenuncioSoapRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var poliza = Poliza.Crear(
                numeroPoliza: request.Poliza.NumeroPoliza
            );

            var denunciante = Denunciante.Crear(
                telefono: request.Denunciante.Telefono,
                nombreCompleto: request.Denunciante.NombreCompleto,
                nombre: request.Denunciante.Nombre,
                apellidos: request.Denunciante.Apellidos,
                rut: request.Denunciante.Rut,
                correo: request.Denunciante.Correo
            );

            var vehiculo = Vehiculo.Crear(
                patente: request.Vehiculo.Patente,
                numeroMotor: request.Vehiculo.NumeroMotor
            );

            var conductor = Conductor.Crear(
                nombreCompleto: request.Conductor.NombreCompleto,
                rut: request.Conductor.Rut
            );

            Lesionado? lesionado = null;
            if (request.Lesionado != null)
            {
                lesionado = Lesionado.Crear(
                    nombreCompleto: request.Lesionado.NombreCompleto,
                    rut: request.Lesionado.Rut,
                    telefono: request.Lesionado.Telefono,
                    correo: request.Lesionado.Correo
                );
            }

            return DenuncioSoap.Crear(
                poliza: poliza,
                denunciante: denunciante,
                vehiculo: vehiculo,
                conductor: conductor,
                lesionado: lesionado
            );
        }
    }
}
