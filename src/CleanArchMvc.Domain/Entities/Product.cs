using CleanArchMvc.Domain.Validation;
using Lombok.NET;

namespace CleanArchMvc.Domain.Entities;

[NoArgsConstructor]
public sealed class Product : Entity
{
    public Product(int id, string name, string description, decimal price, int stock, string? image, int categoryId, Category category)
    {
        ValidateDomainEntity(id, name, description, price, stock, image, categoryId);
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
        Category = category;
    }

    public void Update(int id, string name, string description, decimal price, int stock, string? image, int categoryId, Category category)
    {
        ValidateDomainEntity(id, name, description, price, stock, image, categoryId);
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
        Image = image;
        CategoryId = categoryId;
        Category = category;
    }

    private static void ValidateDomainEntity(int id, string name, string description, decimal price, int stock, string? image, int categoryId)
    {
        DomainExceptionValidation.When(id < 0, "Id cannot be negative");
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Name cannot be null or empty");
        DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Description cannot be null or empty");
        DomainExceptionValidation.When(price < 0, "Price cannot be negative");
        DomainExceptionValidation.When(stock < 0, "Stock cannot be negative");
        DomainExceptionValidation.When(image == "", "Image cannot be empty");
        DomainExceptionValidation.When(categoryId < 0, "Category Id cannot be negative");
    }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string? Image { get; private set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
