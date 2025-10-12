using ICore.Siniestro.Dominio.Entidades;

namespace ICore.Siniestro.Aplicacion.Contratos.Persistencia
{
    public interface IArchivoContract
    {
        Task<bool> GuardarArchivo(Archivo archivo);
    }
}
