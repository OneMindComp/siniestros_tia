namespace ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte
{
    public class Siniestro
    {
        public DateTime Fecha { get; private set; }
        public string Relato { get; private set; } = default!;
        public bool? TerminosYCondiciones { get; private set; }
        public string? Region { get; private set; }
        public string? Comuna { get; private set; }
        public string? Direccion { get; private set; }
        public string? Ubicacion { get; private set; }
        public string? NumeroPartePolicial { get; private set; }
        public string? CentroVeterinario { get; private set; }
        public List<string>? Archivos { get; private set; }
        public string? LugarSiniestro { get; private set; }

        private Siniestro() { }

        private Siniestro(DateTime fecha, string relato)
        {
            Fecha = fecha;
            Relato = relato;
        }

        public static Siniestro Crear(DateTime fecha, string relato)
        {
            return new Siniestro(fecha, relato);
        }

        public Siniestro AgregarTerminosYCondiciones(bool? terminosYCondiciones)
        {
            TerminosYCondiciones = terminosYCondiciones;
            return this;
        }

        public Siniestro AgregarUbicacion(
            string? region,
            string? comuna,
            string? direccion,
            string? ubicacion,
            string? lugarSiniestro)
        {
            Region = region;
            Comuna = comuna;
            Direccion = direccion;
            Ubicacion = ubicacion;
            LugarSiniestro = lugarSiniestro;
            return this;
        }

        public Siniestro InformacionAdicional(
            string? numeroPartePolicial,
            string? centroVeterinario,
            List<string>? archivos)
        {
            NumeroPartePolicial = numeroPartePolicial;
            CentroVeterinario = centroVeterinario;
            Archivos = archivos;
            return this;
        }
    }
}
