namespace ICore.Siniestro.Dominio.Entidades.Falabella
{
    /// <summary>
    /// Exposiciones al riesgo
    /// </summary>
    public class Exposicion : Entidad<long>
    {
        // Propiedades de Cobertura
        public string? DescripcionCobertura { get; private set; }
        public string? CodigoCobertura { get; private set; }
        public string? MonedaCobertura { get; private set; }

        // Propiedades de Monto Asegurado
        public string? MontoAseguradoActual { get; private set; }
        public string? MontoAseguradoOriginal { get; private set; }

        // Propiedades de Reserva y Pago
        public int? Reserva { get; private set; }
        public int? Pago { get; private set; }
        public int? ReservaMonedaLocal { get; private set; }
        public int? PagoMonedaLocal { get; private set; }

        // Propiedades booleanas y no utilizadas
        public bool? FirstParty { get; private set; }

        // Colecciones relacionadas
        public List<string>? ContactosRelacionados { get; private set; }
        public List<string>? Modelos { get; private set; }
        public List<string>? DatosAdicionales { get; private set; }
        public List<string>? Vehiculos { get; private set; }

        // Lista de riesgos
        public List<Riesgo>? Riesgos { get; private set; }

        // Constructor privado vacio para evitar instanciacion directa
        private Exposicion() { }

        // Metodos para asignar propiedades
        public void AsignarCobertura(string descripcion, string codigo, string moneda)
        {
            DescripcionCobertura = descripcion;
            CodigoCobertura = codigo;
            MonedaCobertura = moneda;
        }

        public void AsignarMontos(string montoActual, string montoOriginal)
        {
            MontoAseguradoActual = montoActual;
            MontoAseguradoOriginal = montoOriginal;
        }

        public void AsignarReservasYPagos(int reserva, int pago, int reservaLocal, int pagoLocal)
        {
            Reserva = reserva;
            Pago = pago;
            ReservaMonedaLocal = reservaLocal;
            PagoMonedaLocal = pagoLocal;
        }

        public void AsignarFirstParty(bool firstParty)
        {
            FirstParty = firstParty;
        }

        public void AsignarContactosRelacionados(List<string> contactos)
        {
            ContactosRelacionados = contactos;
        }

        public void AsignarModelos(List<string> modelos)
        {
            Modelos = modelos;
        }

        public void AsignarDatosAdicionales(List<string> datos)
        {
            DatosAdicionales = datos;
        }

        public void AsignarVehiculos(List<string> vehiculos)
        {
            Vehiculos = vehiculos;
        }

        public void AsignarRiesgos(List<Riesgo> riesgos)
        {
            Riesgos = riesgos;
        }

        // Metodo estatico para crear una instancia inicial con minimos parametros necesarios
        public static Exposicion Crear()
        {
            return new Exposicion();
        }
    }
}
