namespace ICore.Siniestro.Dominio.Entidades
{
    public class PartePolicial : Entidad<long>
    {
        public DateTime Fecha { get; private set; }
        public long Numero { get; private set; }

        private PartePolicial()
        {
        }

        private PartePolicial(DateTime fecha, long numero)
        {
            Fecha = fecha;
            Numero = numero;
        }

        public static PartePolicial Crear(DateTime fecha, long numero)
        {
            return new PartePolicial(fecha, numero);
        }
    }
}
