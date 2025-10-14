namespace ICore.Siniestro.Dominio.Entidades.Denuncio.Soporte
{
    public class Lesionado
    {
        public string NombreCompleto { get; private set; } = default!;
        public string Rut { get; private set; } = default!;
        public string Telefono { get; private set; } = default!;
        public string Correo { get; private set; } = default!;

        private Lesionado() { }

        private Lesionado(string nombreCompleto, string rut, string telefono, string correo)
        {
            NombreCompleto = nombreCompleto;
            Rut = rut;
            Telefono = telefono;
            Correo = correo;
        }

        public static Lesionado Crear(string nombreCompleto, string rut, string telefono, string correo)
        {
            return new Lesionado(nombreCompleto, rut, telefono, correo);
        }
    }
}
