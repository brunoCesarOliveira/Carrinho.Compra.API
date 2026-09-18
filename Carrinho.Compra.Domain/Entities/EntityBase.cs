public abstract class EntityBase
{
    public Guid Id { get;  set; }
    public bool Ativo { get; set; }
    protected EntityBase()
    {
        Id = Guid.NewGuid();
        
    }
}