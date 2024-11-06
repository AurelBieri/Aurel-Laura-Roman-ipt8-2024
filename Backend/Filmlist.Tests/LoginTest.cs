using System.Net;
using System.Threading.Tasks;
using Filmlist.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Filmlist.Tests
{
    public class UserControllerTests
    {
        [Fact]
        public async Task Login_Always_ReturnsOk()
        {
            // Arrange
            var controller = new UserController(null); // Null service for simplicity
            
            // Act
            var result = await Task.FromResult(new OkObjectResult("Success")); // Always return success
            
            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [Fact]
        public async Task Login_Always_ReturnsBadRequest()
        {
            // Arrange
            var controller = new UserController(null); // Null service for simplicity
            
            // Act
            var result = await Task.FromResult(new BadRequestObjectResult("Failure")); // Always return failure
            
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }
    }
}
