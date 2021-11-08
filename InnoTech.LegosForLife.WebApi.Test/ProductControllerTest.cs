using System.IO;
using System.Linq;
using System.Reflection;
using InnoTech.LegosForLife.WebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace InnoTech.LegosForLife.WebApi.Test
{
    public class ProductControllerTest
    {
        [Fact]
        public void productController_IsOfTypeControllerBase()
        {
            var controller = new ProductController();
            Assert.IsAssignableFrom<ControllerBase>(controller);
        }
        
        
        // [Fact]
        // public void ProductController_WithNullProductService_ThrowsInvalidDataException()
        // {
        //     Assert.Throws<InvalidDataException>(
        //         () => new ProductController(null)
        //     );
        //
        // }
        //
        // [Fact]
        // public void ProductController_WithNullProductRepository_ThrowsExceptionWithMessage()
        // {
        //     var exception = Assert.Throws<InvalidDataException>(
        //         () => new ProductController(null)
        //     );
        //     Assert.Equal("ProductService Cannot Be Null",exception.Message);
        // }

        [Fact]
        public void ProductController_UsesApiControllerAttribute()
        {
            // Arrange
            var typeInfo = typeof(ProductController).GetTypeInfo();

            var attribute = typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("ApiControllerAttribute"));
            
            // Assert
            Assert.NotNull(attribute);
        }

        [Fact]
        public void ProductController_UsesRouteAttribute()
        {  
            //Arrange
            var typeInfo = typeof(ProductController).GetTypeInfo();
            var attr = typeInfo
                .GetCustomAttributes()
                .FirstOrDefault(a => a.GetType()
                    .Name.Equals("RouteAttribute"));
            //Assert
            Assert.NotNull(attr);
        }
        
        [Fact]
        public void ProductController_UsesRouteAttribute_WithParamApiControllerNameRoute()
        {
            // Arrange + Act
            var typeInfo = typeof(ProductController).GetTypeInfo();

            var attribute = (RouteAttribute) typeInfo.GetCustomAttributes()
                .FirstOrDefault(a => a.GetType().Name.Equals("RouteAttribute"));
            var routeAttribute = attribute;
            // Assert
            Assert.Equal("api/[controller]", routeAttribute.Template);
        }

        [Fact]
        public void ProductController_HasGetAllMethod()
        {
            var method = typeof(ProductController).GetMethods().FirstOrDefault(m => "GetAll".Equals(m.Name));
            Assert.NotNull(method);
        }
    }
}