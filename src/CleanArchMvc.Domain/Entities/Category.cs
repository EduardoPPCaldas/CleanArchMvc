using CleanArchMvc.Domain.Validation;
using Lombok.NET;

namespace CleanArchMvc.Domain.Entities;

[NoArgsConstructor]
public sealed class Category : Entity
{
    public Category(int id, string name)
    {
        ValidateDomainEntity(id, name);
        Id = id;
        Name = name;
    }

    public void Update(int id, string name)
    {
        ValidateDomainEntity(id, name);
        Id = id;
        Name = name;
    }

    private static void ValidateDomainEntity(int id, string name)
    {
        DomainExceptionValidation.When(id < 0, "Id cannot be negative");
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty");
    }
    
    public string Name { get; private set; }
    public ICollection<Product> Products { get; }  = new List<Product>();
}
