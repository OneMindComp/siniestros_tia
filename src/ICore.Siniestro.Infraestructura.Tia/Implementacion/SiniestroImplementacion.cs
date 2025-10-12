using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Core;
using ICore.Siniestro.Dominio.Entidades.Falabella;
using ICore.Siniestro.Dominio.Entidades.FraudKeeper;
using ICore.Siniestro.Dominio.Enumeradores;
using ICore.Siniestro.Infraestructura.Tia.Dto;
using ICore.Siniestro.Infraestructura.Tia.Helper;
using Microsoft.Extensions.Logging;
using Sbins.Comunes.Excepciones;
using System.Globalization;

namespace ICore.Siniestro.Infraestructura.Tia.Implementacion
{
    public class SiniestroImplementacion : ISiniestroContract
    {
        private readonly ITiaApi _tiaApi;
        private readonly ILogger<SiniestroImplementacion> _logger;
        private readonly IMapper _mapper;

        public SiniestroImplementacion(ITiaApi tiaApi, ILogger<SiniestroImplementacion> logger, IMapper mapper)
        {
            _tiaApi = tiaApi;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<Dominio.Entidades.FraudKeeper.Siniestro>> ObtenerSiniestroFraudKepper(string numeroCaso)
        {
            List<Dominio.Entidades.FraudKeeper.Siniestro> siniestrosFraud = new();

            try
            {
                var response = await _tiaApi.GetClFrdkeepObjectAsync(numeroCaso, 1, 25);

                //Datos Siniestro
                var datosSiniestros = response.Content.ClFrdkeep1.ClaimArray;


                foreach (var datoSiniestro in datosSiniestros)
                {
                    var demandanteSiniestro = new List<Dominio.Entidades.FraudKeeper.Participante>();
                    //Datos Poliza
                    var datosPoliza = datoSiniestro.PolicyArray.FirstOrDefault();

                    //Se llenan participantes con rol asegurado
                    var aseguradosPoliza = datosPoliza!.InsuredArray.Select(p =>
                    {
                        var persona = Dominio.Entidades.FraudKeeper.Persona.Crear(
                            nombre: p.Name?.ToString(),
                            rut: p.TaxId?.ToString(),
                            direccion: p.Address?.ToString(),
                            ciudad: p.City?.ToString(),
                            estado: p.State?.ToString(),
                            pais: p.Country?.ToString(),
                            tipoPersona: p.PersonType?.ToString(),
                            nombreADesplegar: p.DisplayName?.ToString(),
                            clienteDesde: null
                            );
                        return ParticipanteHelper.CrearParticipante([TipoParticipante.Asegurado.ToString()], persona, null);
                    }).ToList();


                    //Se llenan las exposiciones del siniestro
                    var exposiciones = datoSiniestro.ExposuresArray.Select(e =>
                    {

                        //Se llenan participantes de siniestro con rol demandante
                        demandanteSiniestro = e.ClaimantArray.Select(c =>
                        {
                            var demandante = Dominio.Entidades.FraudKeeper.Persona.Crear(
                                nombre: c.DisplayName?.ToString(),
                                rut: c.TaxId?.ToString(),
                                direccion: c.Address?.ToString(),
                                ciudad: c.City?.ToString(),
                                estado: c.State?.ToString(),
                                pais: c.Country?.ToString(),
                                tipoPersona: c.PersonType?.ToString(),
                                nombreADesplegar: c.DisplayName?.ToString(),
                                clienteDesde: null
                                );
                            return ParticipanteHelper.CrearParticipante([TipoParticipante.Demandante.ToString()], demandante, null);
                        }).ToList();

                        //Se llenan los riesgos del siniestro
                        var riesgos = e.RiskArray.Select(data =>
                        {
                            return RiesgoHelper.CrearRiesgo(
                                numero: Convert.ToInt32(data.RiskNumber ?? null),
                                codigo: data.RiskCode?.ToString(),
                                descripcion: data.RiskDescription?.ToString(),
                                especificaciones: []
                                );
                        }).ToList();

                        return ExposicionesHelper.CrearExposicion(
                            modelos: [],
                            datosAdicionales: [],
                            vehiculos: [],
                            riesgo: riesgos,
                            descripcionCobertura: e.CoverageDescription?.ToString(),
                            codigoCobertura: e.CoverageCode?.ToString(),
                            monedaCobertura: e.CoverageCurrency?.ToString(),
                            actualMontoAsegurado: e.CurrentInsuredAmount?.ToString(),
                            montoAseguradoOriginal: e.OriginalInsuredAmount?.ToString(),
                            reservas: !String.IsNullOrWhiteSpace(e.Reserves?.ToString()) ? Convert.ToInt32(e.Reserves) : default,
                            pagos: !String.IsNullOrWhiteSpace(e.Payments?.ToString()) ? Convert.ToInt32(e.Payments) : default,
                            reservasMonedaLocal: !String.IsNullOrWhiteSpace(e.ReservesLocalCurrency?.ToString()) ? Convert.ToInt32(e.ReservesLocalCurrency) : default,
                            pagosMonedaLocal: !String.IsNullOrWhiteSpace(e.PaymentsLocalCurrency?.ToString()) ? Convert.ToInt32(e.PaymentsLocalCurrency) : default,
                            firstParty: e.FirstParty is bool value && value,
                            contactosRelacionados: null);
                    }).ToList();

                    //Se llena la Entidad Poliza
                    var poliza = Poliza.Crear(
                        numeroPoliza: datosPoliza?.PolicyNumber?.ToString(),
                        fechaCreacion: datosPoliza?.Created?.ToString(),
                        fechaInicio: datosPoliza?.EffectiveDate?.ToString(),
                        fechaExpiracion: datosPoliza?.ExpirationDate?.ToString(),
                        fechaCancelacion: datosPoliza?.CancelationDate?.ToString(),
                        fechaRehabilitacion: datosPoliza?.RehabilitationDate?.ToString(),
                        codigoProducto: datosPoliza?.ProductCode?.ToString(),
                        codigoProductor: datosPoliza?.ProducerCode?.ToString(),
                        textoAdicional: datosPoliza?.AdditionalText?.ToString(),
                        metodoVenta: datosPoliza?.SellMethod?.ToString(),
                        prima: datosPoliza?.Premium != null ? Convert.ToDouble(datosPoliza?.Premium.ToString()) : default!,
                        primaConImpuestos: !String.IsNullOrWhiteSpace(datosPoliza?.PremiumPlusTaxes.ToString()) && datosPoliza?.PremiumPlusTaxes is double value ? (double?)value : default,
                        numeroCertificado: null,
                        lineaNegocio: null,
                        ramo: null
                        );


                    //Se llena la Entidad Siniestro
                    var siniestro = Dominio.Entidades.FraudKeeper.Siniestro.Crear(
                        fechaCreacion: Convert.ToDateTime(datoSiniestro?.Created?.ToString()),
                        idPublico: datoSiniestro?.PublicId?.ToString(),
                        numeroSiniestro: datoSiniestro?.Number?.ToString(),
                        fechaAcontecimiento: Convert.ToDateTime(datoSiniestro?.IncidentDate?.ToString()),
                        fechaApertura: Convert.ToDateTime(datoSiniestro?.OpenDate?.ToString()),
                        fechaNotificacion: Convert.ToDateTime(datoSiniestro?.NotificationDate?.ToString()),
                        descripcion: datoSiniestro?.Statement?.ToString(),
                        causaPrimaria: datoSiniestro?.PrimaryCause?.ToString(),
                        direccion: datoSiniestro?.Address?.ToString(),
                        pais: datoSiniestro?.Country?.ToString(),
                        hasMatters: datoSiniestro?.HasMatters is bool MattersValue && MattersValue,
                        coberturaEnCuestion: datoSiniestro?.CoverageInQuestion is bool coverageValue && coverageValue,
                        notasAdicionales: datoSiniestro?.AdditionalNotes?.ToString(),
                        administradorReclamos: datoSiniestro?.ClaimAdministrator?.ToString(),
                        numeroDeVehiculos: datoSiniestro?.NumberOfVehicles != null && datoSiniestro?.NumberOfVehicles is int vehiclesValue ? Convert.ToInt32(vehiclesValue) : default,
                        numeroDeTestigos: datoSiniestro?.NumberOfWitnesses != null && datoSiniestro?.NumberOfWitnesses is int TestigosValue ? Convert.ToInt32(TestigosValue) : default,
                        montoTotalReclamo: !String.IsNullOrWhiteSpace(datoSiniestro?.TotalClaimAmount?.ToString()) ? Convert.ToDecimal(datoSiniestro?.TotalClaimAmount ?? null) : default,
                        informacionExterna: [],
                        poliza: poliza,
                        exposiciones: exposiciones,
                        participantes: [],
                        dataAdicional: [],
                        lenguaje: null,
                        archivos: null,
                        branchGroupCode: null,
                        branchGroupDescription: null,
                        estadoSiniestro: null,
                        codigoEstado: null,
                        ajustador: null,
                        codigoCatastrofe: null,
                        fechaReporteSiniestro: null,
                        moneda: null,
                        reservaIndemnizacion: null,
                        reservaHonorarios: null,
                        porcentajeSeguidor: null
                        );
                    siniestro.AgregarParticipantes(demandanteSiniestro);
                    siniestro.AgregarParticipantes(aseguradosPoliza);

                    siniestrosFraud.Add(siniestro);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en siniestros fraudkeeper implementacion");
                throw new InvalidOperationException("No se pudo obtener siniestro fraudkeeper.", ex);

            }
            return siniestrosFraud;
        }

        public async Task<List<ICore.Siniestro.Dominio.Entidades.Siniestro>> ObtenerSiniestros(string numeroSiniestro)
        {
            try
            {
                var tiaApi = await _tiaApi.GetAwdSinObjectAsync(numeroSiniestro, 1, 25);
                var siniestros = tiaApi.Content.AwdSin1.Sbv92DodAwdSiniestroArray;

                List<ICore.Siniestro.Dominio.Entidades.Siniestro> siniestrosAwd = new();

                foreach (var siniestro in siniestros)
                {
                    AfectadoDto afectadoDto = new()
                    {
                        Rut = siniestro.RutAfectado.ToString()!,
                        Nombre = siniestro.Afectado.ToString()!
                    };

                    AseguradoDto aseguradoDto = new()
                    {
                        Rut = siniestro.RutAsegurado.ToString()!,
                        Nombre = siniestro.Asegurado.ToString()!,
                    };

                    LiquidadorDto liquidadorDto = new()
                    {
                        Id = siniestro.IdLiquidador.ToString()!,
                        Nombre = siniestro.Liquidador.ToString()!
                    };

                    CorredorDto corredorDto = new()
                    {
                        Id = siniestro.IdCorredor.ToString()!,
                        Nombre = siniestro.Corredor.ToString()!
                    };

                    PolizaDto polizaDto = new()
                    {
                        NumeroPoliza = siniestro.Poliza.ToString()!,
                        NumeroCertificado = Convert.ToInt32(siniestro.Certificado),
                        LineaNegocio = siniestro.LineaNegocio.ToString()!,
                        InicioVigencia = ParseDateTime(siniestro.InicioVigencia),
                        TerminoVigencia = ParseDateTime(siniestro.TerminoVigencia),
                        Ramo = siniestro.Ramo.ToString()!,
                        Asegurado = aseguradoDto,
                        Corredor = corredorDto
                    };

                    SiniestroDto siniestroAWDDto = new()
                    {
                        NumeroSiniestro = Convert.ToInt32(siniestro.NroSiniestro),
                        EstadoSiniestro = siniestro.Estado.ToString()!,
                        CodigoEstado = siniestro.CodEstado.ToString()!,
                        Ajustador = siniestro.Ajustador.ToString()!,
                        FechaPerdida = ParseDateTime(siniestro.FechaPerdida),
                        LugarPerdida = siniestro.LugarPerdida.ToString()!,
                        DescripcionPerdida = siniestro.DescripcionPerdida.ToString()!,
                        CodigoCatastrofe = siniestro.CodCatastrofe.ToString()!,
                        FechaReporteSiniestro = ParseDateTime(siniestro.FechaReporteSiniestro),
                        FechaCreacion = ParseDateTime(siniestro.FechaCreacion),
                        Moneda = siniestro.Moneda.ToString()!,
                        ReservaIndemnizacion = Convert.ToInt32(siniestro.ReservaIndemnizacion),
                        ReservaHonorarios = Convert.ToInt32(siniestro.ReservaHonorarios),
                        PorcentajeSeguidor = Convert.ToInt32(siniestro.PorcentajeSeguidor),
                        Afectado = afectadoDto,
                        Liquidador = liquidadorDto,
                        Poliza = polizaDto
                    };

                    var siniestroAWD = _mapper.Map<ICore.Siniestro.Dominio.Entidades.Siniestro>(siniestroAWDDto);


                    _logger.LogInformation("Se extrajo el siniestro numero: {Siniestro} correctamente", siniestro.NroSiniestro);

                    siniestrosAwd.Add(siniestroAWD);
                }


                return siniestrosAwd;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un problema al extraer los siniestros fraudkeeper desde Tia");

                throw new InfraestructureException(ex.Message);
            }
        }

        public async Task<List<EstadoOrdenTrabajo>> ObtenerEstadoOrdenTrabajo(string numeroOrden)
        {
            try
            {
                var respuestaTia = await _tiaApi.GetFalWoUpdObjectAsync(numeroOrden, 1, 25);
                var respuestaEstadoOrdenTia = respuestaTia.Content.FalWoUpd1.DodFalWoUpdArray;

                List<EstadoOrdenTrabajo> estadosOrden = new();
                foreach (var estado in respuestaEstadoOrdenTia)
                {
                    var estadoOrdenTrabajo = EstadoOrdenTrabajo.Crear();

                    estadoOrdenTrabajo.DatosServicioTecnico(
                        estado.NumeroServicioTecnico?.ToString(),
                        estado.NumeroF11?.ToString(),
                        estado.CodigoServicioTecnico?.ToString(),
                        estado.NombreServicioTecnico?.ToString(),
                        estado.TelefonoServicioTecnico?.ToString(),
                        estado.SucursalServicioTecnico?.ToString(),
                        estado.NumeroOTServicioTecnico?.ToString());

                    estadoOrdenTrabajo.DatosProducto(
                        estado.FechaRecepcionProducto?.ToString(),
                        estado.NumeroGuiaRecepcion?.ToString(),
                        estado.FechaEntregaProducto?.ToString(),
                        estado.NumeroGuiaDespacho?.ToString(),
                        estado.DescripcionRechazoOReparacion?.ToString(),
                        estado.SkuProducto?.ToString(),
                        estado.PrecioProducto?.ToString()
                        );

                    estadoOrdenTrabajo.DatosOrdenTrabajo(
                        estado.EstadoOrdenTrabajo?.ToString(),
                        estado.FechaModificacionEstado?.ToString(),
                        estado.FechaCreacionOT?.ToString()
                        );

                    estadosOrden.Add(estadoOrdenTrabajo);
                }

                return estadosOrden;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en ObtenerEstadoOrdenTrabajo al obtener los estados desde Tia {Message}", ex.Message);

                throw new InfraestructureException(ex.Message);
            }
        }

        static DateTime ParseDateTime(object fecha)
        {
            string formato = "dd-MM-yyyy HH:mm:ss";
            DateTime fechaFormato;

            DateTime.TryParseExact(fecha.ToString(), formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaFormato);

            return fechaFormato;
        }
    }
}