using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Aplicacion.Dtos.Requests.Soap;
using ICore.Siniestro.Aplicacion.Dtos.Responses.Soap;
using ICore.Siniestro.Dominio.Entidades;
using ICore.Siniestro.Dominio.Entidades.Soap;
using ICore.Siniestro.Infraestructura.TiaParty;
using MediatR;
using Microsoft.Extensions.Logging;
using Sbins.Lib.DateTimeManager;

namespace ICore.Siniestro.Aplicacion.Comandos
{
    /// <summary>
    /// Crea siniestro.
    /// </summary>
    public class CrearSiniestroCommand : IRequest<SiniestroPropuestoResponse>
    {
        /// <summary>
        /// Request con data requerida para crear siniestro.
        /// </summary>
        public SiniestroSoapRequest Request { get; set; } = default!;
    }
    /// <summary>
    /// Maneja la logica para crear siniestro.
    /// </summary>
    public class CrearSiniestroCommandHandler : IRequestHandler<CrearSiniestroCommand, SiniestroPropuestoResponse>
    {

        private readonly ISiniestroContract _siniestro;
        private readonly IMapper _mapper;
        private readonly ITiaPartyClient _partyClient;
        private readonly ILogger<CrearSiniestroCommandHandler> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestro"></param>
        /// <param name="mapper"></param>
        /// <param name="partyClient"></param>
        /// <param name="logger"></param>
        public CrearSiniestroCommandHandler(ISiniestroContract siniestro, IMapper mapper, ITiaPartyClient partyClient, ILogger<CrearSiniestroCommandHandler> logger)
        {
            _siniestro = siniestro;
            _mapper = mapper;
            _partyClient = partyClient;
            _logger = logger;
        }
        /// <summary>
        /// Implementa la logica para crear un siniestro.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="Sbins.Comunes.Excepciones.ApplicationException"></exception>
        public async Task<SiniestroPropuestoResponse> Handle(CrearSiniestroCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Se inicia el metodo CrearSiniestroCommand ");

                var institucionesSalud = _partyClient.V1PartiesGetAsync(default, default, default, default, request.Request.RutInstitucionSalud,
                    default, default, default, default, default, default, default, default, default, default, default, default);
                var institucionSalud = institucionesSalud.Result.Content.FirstOrDefault();
                long InstitucionSaludId = 0;
                if (institucionSalud != null)
                {
                    InstitucionSaludId = institucionSalud.Id;
                }
                var siniestro = MapSiniestroSoap(request.Request, InstitucionSaludId);
                var response = await _siniestro.CrearSiniestroSoap(siniestro);

                if (response != null)
                {
                    _logger.LogInformation("Se envio el siniestro {S} a Tia correctamente", response.NumeroSiniestro);
                }

                var respuesta = _mapper.Map<SiniestroPropuestoResponse>(response);

                return respuesta;

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException("An error occurred in CrearSiniestroCommandHandler", ex);

            }
        }

        private static SiniestroSoap MapSiniestroSoap(SiniestroSoapRequest input, long institucionSaludId)
        {

            Dominio.Entidades.Soap.Poliza poliza = Dominio.Entidades.Soap.Poliza.Crear(
                numeroPoliza: input.NumeroPoliza
                );
            Vehiculo vehiculo = Vehiculo.Crear(
                patente: input.Patente
                );
            Contratante contratante = Contratante.Crear(
                numeroDocumento: input.RutContratante,
                nombre: input.NombreContratante
                );
            Lesionado lesionado = Lesionado.Crear(
                numeroDocumento: input.RutLesionado,
                nombre: input.NombreLesionado
                );
            PartePolicial parte = null!;
            if (input.NumeroParte > 0)
            {
                parte = PartePolicial.Crear(
                fecha: DateTimeParse.ParseToDateTimeUTC(input.FechaParte),
                numero: input.NumeroParte
                );
            }
            InstitucionSalud institucionSalud = InstitucionSalud.Crear(
                rut: input.RutInstitucionSalud,
                nombre: input.NombreInstitucionSalud,
                codigoInterno: input.NumeroInterno!
                );
            if (institucionSaludId > 0)
            {
                institucionSalud.setId(institucionSaludId);
            }
            Factura factura = Factura.Crear(
                numeroFactura: input.NumeroFactura,
                montoBruto: input.MontoBruto,
                iva: input.Iva,
                montoNeto: input.MontoNeto
                );
            SiniestroSoap soap = SiniestroSoap.Crear(
                fecha: DateTimeParse.ParseToDateTimeUTC(input.Fecha),
                tipoEvento: input.TipoEvento,
                controlador: input.Controlador,
                liquidador: input.Liquidador,
                poliza: poliza,
                vehiculo: vehiculo,
                contratante: contratante,
                lesionado: lesionado,
                parte: parte,
                institucionSalud: institucionSalud,
                factura: factura
                );
            return soap;
        }
    }
}
