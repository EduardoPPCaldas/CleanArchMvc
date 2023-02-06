using System;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class ProductTests
{
    [Fact]
    public void CreateProduct_WithValidParameters_ResultObjectState()
    {
        Action action = () => new Product(1, "Product name", "Product description", (decimal)10.0, 1, null, new Category(1, "Category name"));

        action
            .Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Fact]
    public void CreateProduct_WithInvalidParameters_ThrowsException()
    {
        Action action = () => new Product(-1, "", "", (decimal)-10.0, -1, "", new Category(1, "Category name"));

        action
            .Should()
            .Throw<DomainExceptionValidation>();
    }
}
