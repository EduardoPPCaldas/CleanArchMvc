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
}