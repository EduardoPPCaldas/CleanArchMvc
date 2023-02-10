namespace CleanArchMvc.Infra.Data.Errors;

public class EntityNotFoundException : Exception
{
    public EntityNotFoundException(int id) : base($"Entity with id: {id} was not found")
    {
        Id = id;
    }

    public int Id { get; }
}
