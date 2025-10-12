namespace ICore.Siniestro.Dominio.Entidades
{
    public class Factura : Entidad<long>
    {
        public long NumeroFactura { get; private set; }
        public decimal MontoBruto { get; private set; }
        public decimal Iva { get; private set; }
        public decimal MontoNeto { get; private set; }

        private Factura() { }

        private Factura(long numeroFactura, decimal montoBruto, decimal iva, decimal montoNeto)
        {
            NumeroFactura = numeroFactura;
            MontoBruto = montoBruto;
            Iva = iva;
            MontoNeto = montoNeto;
        }

        public static Factura Crear(long numeroFactura, decimal montoBruto, decimal iva, decimal montoNeto)
        {
            return new Factura(numeroFactura, montoBruto, iva, montoNeto);
        }
    }

}
