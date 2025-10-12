using FluentValidation;
using ICore.Siniestro.Aplicacion.Dtos.Requests.Soap;
using Sbins.Lib.DateTimeManager;

namespace ICore.Siniestro.Aplicacion.Validaciones
{
    /// <summary>
    /// Clase de configuracion fluent validation SiniestroSoapRequest.
    /// </summary>
    public class SiniestroSoapValidacion : AbstractValidator<SiniestroSoapRequest>
    {
        /// <summary>
        /// Constructor que implementa las validaciones.
        /// </summary>
        public SiniestroSoapValidacion()
        {
            RuleFor(c => c.Fecha).NotNull().NotEmpty().Must(DateTimeValidator.EsFormatoFechaEspanolValido!).WithMessage("Formato de fecha no valido, formato esperado: dd-MM-yyyy");
            RuleFor(c => c.FechaParte).NotNull().NotEmpty().Must(DateTimeValidator.EsFormatoFechaEspanolValido!).WithMessage("Formato de fecha no valido, formato esperado: dd-MM-yyyy");
            RuleFor(c => c.Controlador).NotNull().NotEmpty();
            RuleFor(c => c.Liquidador).NotNull().NotEmpty();
            RuleFor(c => c.Iva).NotNull();
            RuleFor(c => c.MontoBruto).NotNull();
            RuleFor(c => c.MontoNeto).NotNull();
            RuleFor(c => c.NombreContratante);
            RuleFor(c => c.NombreInstitucionSalud).NotNull().NotEmpty();
            RuleFor(c => c.NombreLesionado).NotNull().NotEmpty();
            RuleFor(c => c.NumeroFactura).NotNull().NotEmpty();
            RuleFor(c => c.NumeroInterno);
            RuleFor(c => c.NumeroParte).NotNull().NotEmpty();
            RuleFor(c => c.NumeroPoliza).NotNull().NotEmpty();
            RuleFor(c => c.Patente).NotNull().NotEmpty();
            RuleFor(c => c.RutContratante);
            RuleFor(c => c.RutInstitucionSalud).NotNull().NotEmpty();
            RuleFor(c => c.RutLesionado).NotNull().NotEmpty();
            RuleFor(c => c.TipoEvento).NotNull().NotEmpty();
        }
    }
}
