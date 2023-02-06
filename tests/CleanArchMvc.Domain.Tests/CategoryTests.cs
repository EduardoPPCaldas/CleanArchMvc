using System;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Tests;

public class CategoryTests
{
    [Fact]
    public void CreateCategory_WithValidParameters_ResultObjectState()
    {
        Action action = () => new Category(1, "Category name");

        action
            .Should()
            .NotThrow<DomainExceptionValidation>();
    }

    [Theory]
    [InlineData(-1, "category name")]
    [InlineData(1, "")]
    [InlineData(1, null)]
    public void CreateCategory_WithInvalidParameters_ThrowsException(int id, string name)
    {
        Action action = () => new Category(id, name);

        action
            .Should()
            .Throw<DomainExceptionValidation>();
    }
}