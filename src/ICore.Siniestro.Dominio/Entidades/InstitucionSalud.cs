namespace ICore.Siniestro.Dominio.Entidades
{
    public class InstitucionSalud : Entidad<long>
    {
        public string Rut { get; private set; } = default!;
        public string Nombre { get; private set; } = default!;
        public string CodigoInterno { get; private set; } = default!;

        private InstitucionSalud()
        {
        }

        private InstitucionSalud(string rut, string nombre, string codigoInterno)
        {
            Rut = rut;
            Nombre = nombre;
            CodigoInterno = codigoInterno;
        }

        public static InstitucionSalud Crear(string rut, string nombre, string codigoInterno)
        {
            return new InstitucionSalud(rut, nombre, codigoInterno);
        }
        public void setId(long id)
        {
            Id = id;
        }
    }
}
