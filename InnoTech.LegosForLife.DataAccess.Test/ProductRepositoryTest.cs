using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using EntityFrameworkCore.Testing.Moq;
using InnoTech.LegosForLife.Core.Models;
using Innotech.LegosForLife.DataAccess;
using Innotech.LegosForLife.DataAccess.Entities;
using Innotech.LegosForLife.DataAccess.Repositories;
using InnoTech.LegosForLife.Domain.IRepositories;
using Xunit;

namespace InnoTech.LegosForLife.DataAccess.Test
{
    public class ProductRepositoryTest
    {
        [Fact]
        public void ProductRepository_IsProductRepository()
        {
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProductRepository(fakeContext);
            Assert.IsAssignableFrom<IProductRepository>(repository);
        }

        [Fact]
        public void ProductRepository_WithNullDbContext_ThrowsInvalidDataException()
        {
            var exception = Assert.Throws<InvalidDataException>(() => new ProductRepository(null));
            Assert.Equal("Product Repository Must have a DBContext", exception.Message);
        }

        [Fact]
        public void FindAll_GetAllProductsEntitiesInDBContext_AsAListOfProducts()
        {
            // Arrange
            var fakeContext = Create.MockedDbContextFor<MainDbContext>();
            var repository = new ProductRepository(fakeContext);
            var list = new List<ProductEntity>()
            {
                new ProductEntity() {Id = 1, Name = "Lego1"},
                new ProductEntity() {Id = 2, Name = "Lego2}"},
                new ProductEntity() {Id = 3, Name = "Lego3"}
            };
            fakeContext.Set<ProductEntity>().AddRange(list);
            fakeContext.SaveChanges();
            var expectedList = list.Select(pe => new Product
            {
                Id = pe.Id,
                Name = pe.Name
            }).ToList();
            
            // Act
            var actualResult = repository.FindAll();
            
            // Assert
            Assert.Equal(expectedList, actualResult, new Comparer());

        }
    }
    public class Comparer: IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.Id == y.Id && x.Name == y.Name;
        }

        public int GetHashCode(Product obj)
        {
            return HashCode.Combine(obj.Id, obj.Name);
        }
    }
}