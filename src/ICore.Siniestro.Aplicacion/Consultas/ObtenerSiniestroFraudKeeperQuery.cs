using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Core;
using ICore.Siniestro.Aplicacion.Dtos.Requests;
using ICore.Siniestro.Aplicacion.Dtos.Responses;
using ICore.Siniestro.Aplicacion.Dtos.Responses.Fields.FraudKeeper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace ICore.Siniestro.Aplicacion.Consultas
{
    /// <summary>
    /// Obtiene los siniestros fraudkeeper desde Tia.
    /// </summary>
    public class ObtenerSiniestroFraudKeeperQuery : IRequest<List<ObtenerSiniestroFraudKeeperResponse>>
    {
        /// <summary>
        /// Datos del siniestro.
        /// </summary>
        public SiniestroFraudKeeperRequest Request { get; set; } = default!;

    }

    /// <summary>
    /// Maneja la logica para consultar los siniestros fraudkeeper.
    /// </summary>
    public class ObtenerSiniestroFraudQueryHandler : IRequestHandler<ObtenerSiniestroFraudKeeperQuery, List<ObtenerSiniestroFraudKeeperResponse>>
    {
        private readonly ISiniestroContract _siniestro;
        private readonly ILogger<ObtenerSiniestroFraudQueryHandler> _logger;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="siniestro"></param>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        public ObtenerSiniestroFraudQueryHandler(ISiniestroContract siniestro, ILogger<ObtenerSiniestroFraudQueryHandler> logger, IMapper mapper)
        {
            _siniestro = siniestro;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Implementa la logica para consultar los siniestros fraudkeeper.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="ApplicationException"></exception>
        public async Task<List<ObtenerSiniestroFraudKeeperResponse>> Handle(ObtenerSiniestroFraudKeeperQuery request, CancellationToken cancellationToken)
        {
            List<ObtenerSiniestroFraudKeeperResponse> listaSiniestros = new();

            try
            {
                if (request.Request.NumeroCaso != null)
                {
                    string? numeroCaso = request.Request.NumeroCaso;
                    var siniestros = await _siniestro.ObtenerSiniestroFraudKepper(numeroCaso!);

                    listaSiniestros = siniestros.Select(siniestro => new ObtenerSiniestroFraudKeeperResponse
                    {
                        FechaCreacion = siniestro.FechaCreacion,
                        IdPublico = siniestro.IdPublico,
                        NumeroSiniestro = siniestro.NumeroSiniestro,
                        FechaAcontecimiento = siniestro.FechaAcontecimiento,
                        FechaApertura = siniestro.FechaApertura,
                        FechaNotificacion = siniestro.FechaNotificacion,
                        Descripcion = siniestro.Descripcion,
                        CausaPrimaria = siniestro.CausaPrimaria,
                        Direccion = siniestro.Direccion,
                        Pais = siniestro.Pais,
                        HasMatters = siniestro.TieneImportancia,
                        CoberturaEnCuestion = siniestro.CoberturaEnCuestion,
                        NotasAdicionales = siniestro.NotaAdicional,
                        AdministradorReclamos = siniestro.AdministradorReclamos,
                        NumeroDeVehiculos = siniestro.NumeroDeVehiculos,
                        NumeroDeTestigos = siniestro.NumeroDeTestigos,
                        MontoTotalReclamo = siniestro.MontoTotalReclamo,
                        BranchGroupCode = siniestro.CodigoGrupoRama,
                        BranchGroupDescription = siniestro.DescripcionGrupoRama,
                        Lenguaje = siniestro.Lenguajes,
                        InformacionExterna = siniestro.InformacionExterna,
                        Archivos = siniestro.Archivos,
                        Poliza = _mapper.Map<ObtenerSiniestroFraudKeeperFieldPolizaResponse>(siniestro.Poliza),
                        Exposiciones = siniestro.Exposiciones?
                        .Select(exposicion => _mapper.Map<ObtenerSiniestroFraudKeeperFieldExposicionResponse>(exposicion))
                        .ToList(),
                        DatosAdicionales = siniestro.DatosAdicionales?
                        .Select(dato => _mapper.Map<ObtenerSiniestroFraudKeeperFieldDatosAdicionalesResponse>(dato))
                        .ToList(),
                        Participantes = siniestro.Participantes?
                        .Select(dato => _mapper.Map<ObtenerSiniestroFraudKeeperFieldParticipanteResponse>(dato))
                        .ToList()
                         }).ToList();


                }
                else
                {

                    throw new ArgumentException("Se debe agregar un campo de numero de siniestro o numero de caso");
                
                }
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Hubo un error al tratar los siniestros fraudkeeper");
            
            }
            return listaSiniestros;
        }
    }
}
