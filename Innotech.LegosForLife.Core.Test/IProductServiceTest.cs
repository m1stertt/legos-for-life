using InnoTech.LegosForLife.Core.IServices;
using Moq;
using Xunit;

namespace Innotech.LegosForLife.Core.Test
{
    public class IProductServiceTest
    {
        [Fact]
        public void IProductService_IsAvailable()
        {
            var service = new Mock<IProductService>().Object;
            Assert.NotNull(service);
        }
    }
}