using AutoMapper;
using ICore.Siniestro.Aplicacion.Contratos.Persistencia;
using ICore.Siniestro.Dominio.Entidades.Denuncio;
using ICore.Siniestro.Dominio.Entidades.Falabella;
using ICore.Siniestro.Dominio.Entidades.Soap;
using Microsoft.Extensions.Logging;
using Sbins.Comunes.Excepciones;

namespace ICore.Siniestro.Infraestructura.TiaClaims.Implemetacion
{
    public class SiniestroImplementacion : ISiniestroContract
    {

        private readonly ITiaClaims _tiaClaimsApi;
        private readonly ILogger<SiniestroImplementacion> _logger;

        public SiniestroImplementacion(ITiaClaims tiaClaimsApi, ILogger<SiniestroImplementacion> logger, IMapper mapper)
        {
            _tiaClaimsApi = tiaClaimsApi;
            _logger = logger;
        }

        public async Task<SiniestroPropuesto> CrearSiniestroSoap(SiniestroSoap siniestro)
        {
            try
            {
                var transactionAction1 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "PRE_OP.LOOKUP_OBJECT" },
                        new TransactionValue_TransControl{Name = "policyNoAlt", Value = siniestro.Poliza.NumeroPoliza },
                        new TransactionValue_TransControl{Name = "objectId", Value = siniestro.Vehiculo.Patente },
                        new TransactionValue_TransControl{Name = "incidentDate", Value = siniestro.Fecha.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "civilRegistrationCode", Value = siniestro.InstitucionSalud.Rut}
                    }

                };

                var transactionAction3 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Event,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "eventType", Value = "ACC" },
                        new TransactionValue_TransControl{Name = "causeType", Value = "CLS" },
                        new TransactionValue_TransControl{Name = "incidentDate", Value = siniestro.Fecha.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "isExactIncidentDate", Value =  "N"},
                        new TransactionValue_TransControl{Name = "placeType", Value = "CAR"},
                        new TransactionValue_TransControl{Name = "address", Value = "CAR"}
                    }

                };

                var transactionAction4 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Case,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "informerType", Value = "IP" },
                        new TransactionValue_TransControl{Name = "informerName", Value = siniestro.InstitucionSalud.Nombre },
                        new TransactionValue_TransControl{Name = "notificationDate", Value = DateTime.Now.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "status", Value =  "NO"},
                        new TransactionValue_TransControl{Name = "lossOfBonus", Value = "N"},
                        new TransactionValue_TransControl{Name = "description", Value = siniestro.TipoEvento},
                        new TransactionValue_TransControl{Name = "riskNo", Value =  "105"},
                        new TransactionValue_TransControl{Name = "subriskNo", Value = "0"},
                        new TransactionValue_TransControl{Name = "filedBy", Value = "INT"},
                        new TransactionValue_TransControl{Name = "handler", Value = siniestro.Controlador},
                        new TransactionValue_TransControl{Name = "n901", Value = siniestro.Liquidador.ToString()}
                    }

                };

                if (siniestro.Parte != null)
                {
                    transactionAction4.Values.Add(new TransactionValue_TransControl { Name = "c08", Value = "Y" });
                    transactionAction4.Values.Add(new TransactionValue_TransControl { Name = "c27", Value = siniestro.Parte.Numero.ToString() });
                }
                else
                {
                    transactionAction4.Values.Add(new TransactionValue_TransControl { Name = "c08", Value = "N" });
                }

                transactionAction4.Values.Add(new TransactionValue_TransControl { Name = "c24", Value = siniestro.InstitucionSalud.Rut });

                var transactionAction5 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "CUSTOM.ADD_SSU_CASE" },
                        new TransactionValue_TransControl{Name = "civilRegistrationCode", Value = siniestro.InstitucionSalud.Rut }
                    }
                };

                var transactionAction6 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Item,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "riskNo", Value = "105" },
                        new TransactionValue_TransControl{Name = "subriskNo", Value = "0" },
                        new TransactionValue_TransControl{Name = "status", Value = "NO" },
                        new TransactionValue_TransControl{Name = "handler", Value =  "MIG"},
                        new TransactionValue_TransControl{Name = "itemType", Value = "RE"},
                        new TransactionValue_TransControl{Name = "subitemType", Value = "REM"},
                        new TransactionValue_TransControl{Name = "currencyCode", Value =  "CLP"},
                        new TransactionValue_TransControl{Name = "currencyEstimate", Value = siniestro.Factura.MontoBruto.ToString()},
                        new TransactionValue_TransControl{Name = "estimate", Value = siniestro.Factura.MontoBruto.ToString()},
                        new TransactionValue_TransControl{Name = "description", Value = siniestro.Factura.NumeroFactura.ToString()}
                    }
                };

                if (siniestro.InstitucionSalud.Id > 0)
                {
                    transactionAction6.Values.Add(new TransactionValue_TransControl { Name = "receiverIdNo", Value = siniestro.InstitucionSalud.Id.ToString() });
                }

                var transCollection = new TransactionRequest_TransControl
                {
                    Actions = [
                         transactionAction1,
                         transactionAction3,
                         transactionAction4,
                         transactionAction5,
                         transactionAction6,
                        ]
                };

                if (siniestro.Contratante.NumeroDocumento != siniestro.Lesionado.NumeroDocumento)
                {
                    transCollection.Actions.Add(new TransactionAction_TransControl
                    {
                        Action = TransactionAction_TransControlAction.Custom_Action,
                        Values = new List<TransactionValue_TransControl>
                        {
                            new TransactionValue_TransControl{Name = "action", Value = "CUSTOM.ADD_THIRD_PARTY" },
                            new TransactionValue_TransControl{Name = "civilRegistrationCode", Value = siniestro.Lesionado.NumeroDocumento },
                            new TransactionValue_TransControl{Name = "name", Value =siniestro.Lesionado.Nombre },
                            new TransactionValue_TransControl{Name = "description", Value =  "No contratante"},
                            new TransactionValue_TransControl{Name = "type", Value = "INJ"}
                        }
                    });
                }

                var response = await _tiaClaimsApi.V1PerformTransactionAsync(transCollection);

                var responseData = response.Content;
                var respuesta = SiniestroPropuesto.Crear(numeroSiniestro: responseData.ClaimEventNo);

                return respuesta;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error en siniestro implementacion");
                throw new InvalidOperationException("No se pudo crear siniestro.", ex);
            }
        }

        public async Task<SiniestroPropuesto> CrearSiniestroFalabella(ICore.Siniestro.Dominio.Entidades.Falabella.Siniestro siniestro)
        {
            try
            {
                var transactionAction1 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "PRE_OP.LOOKUP_CERTIFICATE" },
                        new TransactionValue_TransControl{Name = "certificateNo", Value = siniestro.NumeroCertificado },
                        new TransactionValue_TransControl{Name = "incidentDate", Value = siniestro.FechaAcontecimiento?.ToString("yyyy-MM-dd") },
                    }

                };

                var transactionAction2 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "PRE_OP.LOOKUP_TEC_SERVICE" },
                        new TransactionValue_TransControl{Name = "companyRegistrationNo", Value = siniestro.NumeroRegistroCompania },
                    }

                };

                var transactionAction3 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "PRE_OP.SETUP_INFORMER" },
                        new TransactionValue_TransControl { Name = "informerName", Value = siniestro.NombreInformante },
                    }

                };

                var transactionAction4 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Event,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "eventType", Value = siniestro.TipoEvento },
                        new TransactionValue_TransControl{Name = "causeType", Value = siniestro.TipoCausa },
                        new TransactionValue_TransControl{Name = "subcauseType", Value = siniestro.SubTipoCausa },
                        new TransactionValue_TransControl{Name = "incidentDate", Value = siniestro.FechaAcontecimiento?.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "isExactIncidentDate", Value = siniestro.EsFechaExacta},
                        new TransactionValue_TransControl{Name = "placeType", Value = siniestro.TipoLugar},
                        new TransactionValue_TransControl{Name = "address", Value = siniestro.Direccion}
                    }

                };

                var transactionAction5 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Case,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "handler", Value = siniestro.Gestor },
                        new TransactionValue_TransControl{Name = "informerType", Value = siniestro.TipoInformante },
                        new TransactionValue_TransControl{Name = "notificationDate", Value = siniestro.FechaNotificacion?.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "status", Value =  siniestro.EstadoSiniestro},
                        new TransactionValue_TransControl{Name = "lossOfBonus", Value = siniestro.PerdidaBono},
                        new TransactionValue_TransControl{Name = "description", Value = siniestro.Descripcion},
                        new TransactionValue_TransControl{Name = "riskNo", Value = siniestro.Exposiciones?.SelectMany(x => x.Riesgos!).First().Numero.ToString() },
                        new TransactionValue_TransControl{Name = "subriskNo", Value = siniestro.Exposiciones?.SelectMany(x => x.Riesgos!).First().SubNumeroRiesgo },
                        new TransactionValue_TransControl{Name = "filedBy", Value = siniestro.Exposiciones?.SelectMany(x => x.Riesgos!).First().ArchivadoPor },
                        new TransactionValue_TransControl{Name = "c24", Value = siniestro.Participantes?.Select(x => x.Persona!.Rut).First() },
                        new TransactionValue_TransControl{Name = "c26", Value = siniestro.Participantes?.Select(x => x.Persona!.FonoIvr).First() },
                        new TransactionValue_TransControl{Name = "c28", Value = siniestro.Participantes?.Select(x => x.Persona!.FonoContacto).First() },
                        new TransactionValue_TransControl{Name = "c29", Value = siniestro.Participantes?.Select(x => x.Persona!.DireccionComercialCliente).First() },
                        new TransactionValue_TransControl{Name = "c903", Value = siniestro.C903 }
                    }

                };

                var transCollection = new TransactionRequest_TransControl
                {
                    Actions = [
                         transactionAction1,
                         transactionAction2,
                         transactionAction3,
                         transactionAction4,
                         transactionAction5,
                        ]
                };

                var response = await _tiaClaimsApi.V1PerformTransactionAsync(transCollection);

                var responseData = response.Content;
                var respuesta = SiniestroPropuesto.Crear(numeroSiniestro: responseData.ClaimEventNo);

                return respuesta;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error en siniestro implementacion {Mensaje}", ex.Message);
                throw new InfraestructureException(ex.Message);
            }
        }

        public async Task<SiniestroPropuesto> EnviarCourierFalabella(Courier courier)
        {
            try
            {
                var transactionAction1 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "CUSTOM.EXT_WO_UPD" },
                        new TransactionValue_TransControl{Name = "memberNo", Value = courier.NumeroSocio },
                        new TransactionValue_TransControl{Name = "certificateNo", Value = courier.NumeroCertificado },
                        new TransactionValue_TransControl{Name = "extWoNo", Value = courier.NumeroOrdenTrabajo },
                        new TransactionValue_TransControl{Name = "eventDate", Value = courier.FechaEvento },
                        new TransactionValue_TransControl{Name = "transactionId", Value = courier.IdTransaccion },
                        new TransactionValue_TransControl{Name = "messageId", Value = courier.IdMensaje }
                    }
                };

                var transCollection = new TransactionRequest_TransControl
                {
                    Actions =
                    [
                         transactionAction1
                    ]
                };

                var respuestaTia = await _tiaClaimsApi.V1PerformTransactionAsync(transCollection);

                var datosRespuesta = respuestaTia.Content;
                var respuesta = SiniestroPropuesto.Crear(numeroSiniestro: datosRespuesta.ClaimEventNo);

                return respuesta;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al enviar el currier a Tia: {Mensaje}", ex.Message);
                throw new InfraestructureException(ex.Message);
            }
        }

        public async Task<long?> ObtenerNumeroCaso(long numeroSiniestro)
        {
            try
            {
                var casosSiniestro = await _tiaClaimsApi.V1ClaimCasesGetAsync(default, numeroSiniestro, 1, 25);
                var casoSiniestro = casosSiniestro.Content.FirstOrDefault();
                if (casoSiniestro == null)
                {
                    return null;
                }
                else
                {
                    return casoSiniestro.ClaimCaseNo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener numero de caso del siniestro numero:{NumeroSiniestro}, {Mensaje}",numeroSiniestro, ex.Message);
                throw new InfraestructureException(ex.Message);
            }

        }

        public async Task<long?> ObtenerNumeroCaso(string numeroSubsiniestro)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numeroSubsiniestro))
                {
                    throw new ArgumentException("El numero de subsiniestro no puede ser nulo o vacio.", nameof(numeroSubsiniestro));
                }
                long numeroSiniestro = long.Parse(numeroSubsiniestro.Split('-')[0]);
                var casosSiniestro = await _tiaClaimsApi.V1ClaimCasesGetAsync(default, numeroSiniestro, 1, 25);
                var casoSiniestro = casosSiniestro.Content.FirstOrDefault(c => c.ClaimCaseNoAlt.Equals(numeroSubsiniestro));
                if (casoSiniestro == null)
                {
                    return null;
                }
                else
                {
                    return casoSiniestro.ClaimCaseNo;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener numero de caso del siniestro numero:{NumeroSubsiniestro}, {Mensaje}", numeroSubsiniestro, ex.Message);
                throw new InfraestructureException(ex.Message);
            }

        }

        public async Task<SiniestroPropuesto> CrearSiniestro(DenuncioSiniestroSoap denuncio)
        {
            try
            {
                var transactionAction1 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.Custom_Action,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "action", Value = "PRE_OP.LOOKUP_OBJECT" },
                        new TransactionValue_TransControl{Name = "policyNoAlt", Value = denuncio.Poliza.NumeroPoliza },
                        new TransactionValue_TransControl{Name = "objectId", Value = denuncio.Vehiculo.Patente },
                        new TransactionValue_TransControl{Name = "incidentDate", Value = denuncio.Siniestro.Fecha.ToString("yyyy-MM-dd") }
                    }

                };

                var transactionAction2 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Event,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "eventType", Value = "ACC" },
                        new TransactionValue_TransControl{Name = "causeType", Value = "OTR" },
                        new TransactionValue_TransControl{Name = "incidentDate", Value = denuncio.Siniestro.Fecha.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "isExactIncidentDate", Value =  "N"},
                        new TransactionValue_TransControl{Name = "placeType", Value = "ROA"},
                        new TransactionValue_TransControl{Name = "address", Value = denuncio.Siniestro.Direccion}
                    }

                };

                var transactionAction3 = new TransactionAction_TransControl
                {
                    Action = TransactionAction_TransControlAction.New_Case,
                    Values = new List<TransactionValue_TransControl>
                    {
                        new TransactionValue_TransControl{Name = "informerType", Value = "IP" },
                        new TransactionValue_TransControl{Name = "informerName", Value = string.Concat(denuncio.Denunciante.Nombre)},
                        new TransactionValue_TransControl{Name = "notificationDate", Value = DateTime.Now.ToString("yyyy-MM-dd") },
                        new TransactionValue_TransControl{Name = "status", Value =  "NO"},
                        new TransactionValue_TransControl{Name = "lossOfBonus", Value = "N"},
                        new TransactionValue_TransControl{Name = "description", Value = denuncio.Siniestro.Relato},
                        new TransactionValue_TransControl{Name = "riskNo", Value =  "105"},// 101/103/105/125
                        new TransactionValue_TransControl{Name = "subriskNo", Value = "0"},
                        new TransactionValue_TransControl{Name = "filedBy", Value = "INT"}
                    }

                };

                if (denuncio.Siniestro.NumeroPartePolicial != null)
                {
                    transactionAction3.Values.Add(new TransactionValue_TransControl { Name = "c08", Value = "Y" });// Campo: Y=Con Parte Policial / N=Sin Parte Policial
                    transactionAction3.Values.Add(new TransactionValue_TransControl { Name = "c27", Value = denuncio.Siniestro.NumeroPartePolicial.ToString() });
                }
                else
                {
                    transactionAction3.Values.Add(new TransactionValue_TransControl { Name = "c08", Value = "N" });
                }

                transactionAction3.Values.Add(new TransactionValue_TransControl { Name = "c24", Value = denuncio.Denunciante.Rut });
                transactionAction3.Values.Add(new TransactionValue_TransControl { Name = "c25", Value = denuncio.Denunciante.Correo });
                transactionAction3.Values.Add(new TransactionValue_TransControl { Name = "c26", Value = denuncio.Denunciante.Telefono });
           

                

                

                var transCollection = new TransactionRequest_TransControl
                {
                    Actions = [
                         transactionAction1,
                         transactionAction2,
                         transactionAction3
                        ]
                };

                //Sólo se requiere si el lesionado no es el contratante.
                if (denuncio.Lesionado!=null&&(denuncio.Denunciante.Rut != denuncio.Lesionado.Rut))
                {
                    transCollection.Actions.Add(new TransactionAction_TransControl
                    {
                        Action = TransactionAction_TransControlAction.Custom_Action,
                        Values = new List<TransactionValue_TransControl>
                        {
                            new TransactionValue_TransControl{Name = "action", Value = "CUSTOM.ADD_THIRD_PARTY" },
                            new TransactionValue_TransControl{Name = "civilRegistrationCode", Value = denuncio.Lesionado.Rut},
                            new TransactionValue_TransControl{Name = "name", Value =denuncio.Lesionado.NombreCompleto },
                            new TransactionValue_TransControl{Name = "type", Value = "INJ"}
                        }
                    });
                }

                var response = await _tiaClaimsApi.V1PerformTransactionAsync(transCollection);

                var responseData = response.Content;
                var respuesta = SiniestroPropuesto.Crear(numeroSiniestro: responseData.ClaimEventNo);

                return respuesta;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Hubo un error en siniestro implementacion");
                throw new InvalidOperationException("No se pudo crear siniestro.", ex);
            }
        }
    }
}