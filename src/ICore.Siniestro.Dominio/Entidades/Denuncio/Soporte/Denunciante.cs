namespace ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte
{
    public class Denunciante
    {
        public string? NombreCompleto { get; private set; }
        public string? Nombre { get; private set; }
        public string? Apellidos { get; private set; }
        public string? Rut { get; private set; }
        public string Telefono { get; private set; } = default!;
        public string? Correo { get; private set; }

        private Denunciante() { }

        private Denunciante(
            string telefono,
            string? nombreCompleto = null,
            string? nombre = null,
            string? apellidos = null,
            string? rut = null,
            string? correo = null)
        {
            Telefono = telefono;
            NombreCompleto = nombreCompleto;
            Nombre = nombre;
            Apellidos = apellidos;
            Rut = rut;
            Correo = correo;
        }

        public static Denunciante Crear(
            string telefono,
            string? nombreCompleto = null,
            string? nombre = null,
            string? apellidos = null,
            string? rut = null,
            string? correo = null)
        {
            return new Denunciante(telefono, nombreCompleto, nombre, apellidos, rut, correo);
        }
    }
}
