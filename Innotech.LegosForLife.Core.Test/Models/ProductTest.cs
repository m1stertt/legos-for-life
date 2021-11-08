using System.Collections.Generic;
using InnoTech.LegosForLife.Core.IServices;
using InnoTech.LegosForLife.Core.Models;
using Moq;
using Xunit;

namespace Innotech.LegosForLife.Core.Test.Models
{
    public class ProductTest
    {

        public Product _Product;

        public ProductTest()
        {
            _Product = new Product();
        }

        [Fact]
        public void Product_CanBeInitialized()
        {
            Assert.NotNull(_Product);
        }

        [Fact]
        public void Product_SetId_StoredId()
        {
            _Product.Id = 1;
            Assert.Equal(1, _Product.Id);
        }

        [Fact]
        public void SetName_StoreNameAsString()
        {
            _Product.Name = "LegoBrick";
            Assert.Equal("LegoBrick", _Product.Name);
        }
        
        [Fact]
        public void Product_Id_MustBeInt()
        {Assert.True(_Product.Id is int);
        }

        [Fact]
        public void GetProducts_WitNoParams_ReturnsListOfAllProducts()
        {
            var mock = new Mock<IProductService>();
            var fakeList = new List<Product>();
            mock.Setup(s => s.GetProducts()).Returns(new List<Product>());
            var service = mock.Object;
            Assert.Equal(fakeList, service.GetProducts());

        }
    }
    
    
}