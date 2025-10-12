using Microsoft.AspNetCore.Http;

namespace ICore.Siniestro.Dominio.Entidades
{
    public class Archivo
    {
        public IFormFile Data { get; private set; } = default!;
        public long NumeroSiniestro { get; private set; }
        public long? NumeroCaso { get; private set; }=default!;

        private Archivo() { }

        private Archivo(long numeroSiniestro,long? numeroCaso) { 
            NumeroSiniestro = numeroSiniestro;
            NumeroCaso = numeroCaso;
        }

        public static Archivo Crear(long numeroSiniestro, long? numeroCaso)
        {
            return new Archivo(numeroSiniestro, numeroCaso);
        }

        public void EstablecerContenido(IFormFile data)
        {
            Data = data;
        }
    }
}
