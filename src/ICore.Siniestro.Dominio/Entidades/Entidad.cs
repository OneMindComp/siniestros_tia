namespace ICore.Siniestro.Dominio.Entidades
{
    public abstract class Entidad<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
