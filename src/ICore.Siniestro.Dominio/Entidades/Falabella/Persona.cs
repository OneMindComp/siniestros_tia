namespace ICore.Siniestro.Dominio.Entidades.Falabella
{
    /// <summary>
    /// Persona.
    /// </summary>
    public class Persona : Entidad<long>
    {
        // Propiedades de informacion personal
        public string? Nombre { get; private set; }
        public string? Rut { get; private set; }
        public string? Direccion { get; private set; }
        public string? Ciudad { get; private set; }
        public string? Estado { get; private set; }
        public string? Pais { get; private set; }
        public string? TipoPersona { get; private set; }
        public string? NombreADesplegar { get; private set; }
        public DateTime? ClienteDesde { get; private set; }

        // Propiedades de contacto
        public string? FonoContacto { get; private set; }
        public string? FonoIvr { get; private set; }

        // Propiedades de direccion comercial
        public string? DireccionComercialCliente { get; private set; }

        private Persona() { }

        public void AsignarDatosPersonales(string? nombre, string? rut, string? direccion, string? ciudad, string? estado, string? pais)
        {
            Nombre = nombre;
            Rut = rut;
            Direccion = direccion;
            Ciudad = ciudad;
            Estado = estado;
            Pais = pais;
        }

        public void AsignarTipoPersona(string? tipoPersona, string? nombreADesplegar)
        {
            TipoPersona = tipoPersona;
            NombreADesplegar = nombreADesplegar;
        }

        public void AsignarClienteDesde(DateTime? clienteDesde)
        {
            ClienteDesde = clienteDesde;
        }

        public void AsignarContacto(string? fonoContacto, string? fonoIvr)
        {
            FonoContacto = fonoContacto;
            FonoIvr = fonoIvr;
        }

        public void AsignarDireccionComercial(string? direccionComercialCliente)
        {
            DireccionComercialCliente = direccionComercialCliente;
        }

        // Metodo estatico para crear una instancia inicial con minimos parametros necesarios
        public static Persona Crear()
        {
            return new Persona();
        }
    }
}
