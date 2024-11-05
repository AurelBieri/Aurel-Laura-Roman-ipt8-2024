using Xunit;
using Microsoft.AspNetCore.Mvc;
using Filmlist.Controllers;
using Filmlist.Classes;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class UserControllerTests
{
    private readonly UserController _controller;
    private readonly ApplicationDbContext _context;

    public UserControllerTests()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;
        _context = new ApplicationDbContext(options);

        _controller = new UserController(_context);
    }

    [Fact]
    public async Task Register_Returns_CreatedAtAction()
    {
        var newUser = new User { Email = "testuser@example.com", Password = "Password123" };
        var result = await _controller.CreateUser(newUser) as CreatedAtActionResult;

        Assert.NotNull(result);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public async Task Login_Returns_Ok_When_Credentials_Are_Valid()
    {
        var existingUser = new User { Email = "testuser@example.com", Password = "Password123" };
        await _context.Users.AddAsync(existingUser);
        await _context.SaveChangesAsync();

        var loginRequest = new LoginRequest { Email = "testuser@example.com", Password = "Password123" };
        var result = await _controller.Login(loginRequest); // Use await here

        // Assert that the result is of type OkObjectResult
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(200, okResult.StatusCode);
    }

    [Fact]
    public async Task Login_Returns_Unauthorized_When_Credentials_Are_Invalid()
    {
        var loginRequest = new LoginRequest { Email = "nonexistent@example.com", Password = "WrongPassword" };
        var result = await _controller.Login(loginRequest); // Use await here

        // Assert that the result is of type UnauthorizedResult
        var unauthorizedResult = Assert.IsType<UnauthorizedResult>(result);
        Assert.Equal(401, unauthorizedResult.StatusCode);
    }
}
