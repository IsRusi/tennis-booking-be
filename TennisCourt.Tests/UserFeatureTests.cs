
using Bogus;
using Moq;
using TennisCourt.Features.Users.Data;
using TennisCourt.Features.Users.Models;
using TennisCourt.Features.Users.Services;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Tests;

public class UserFeatureTests
{

    private Guid expectedId = Guid.NewGuid();

    [Fact]
    public async Task CreateUser_AllFieldsValid_ReturnId()
    {
        //Arrange
        var createUserDto = new Faker<UserDto>().Generate();

        var mockDataProvider = new Mock<IUsersDataProvider>();

        mockDataProvider.Setup(dataProvider => dataProvider.CreateAsync(It.IsAny<User>())).ReturnsAsync(expectedId);

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await userService.CreateAsync(createUserDto);

        //Assert
        Assert.Equal(expectedId, result);

        mockDataProvider.Verify(
        dataProvider => dataProvider.CreateAsync(It.Is<User>(u => u.Name == createUserDto.Name)),
        Times.Once);
    }

    [Fact]
    public async Task CreateUser_EmailIsEmpty_ReturnsError()
    {
        //Arrange
        var createUserDto = new Faker<UserDto>()
        .RuleFor(u => u.Email, f => "")
        .RuleFor(u => u.Name, f => f.Name.FirstName())
        .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
        .Generate();

        var mockDataProvider = new Mock<IUsersDataProvider>();

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.CreateAsync(createUserDto));

        //Assert
        Assert.Equal(nameof(User.Email), result.ParamName);
        mockDataProvider.Verify(dataProvider => dataProvider.SaveChangesAsync(), Times.Never);
    }

    [Fact]
    public async Task CreateUser_NameIsEmpty_ReturnsError()
    {
        var createUserDto = new Faker<UserDto>()
        .RuleFor(u => u.Email, f => f.Internet.Email())
        .RuleFor(u => u.Name, f => "")
        .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
        .Generate();

        var mockDataProvider = new Mock<IUsersDataProvider>();

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.CreateAsync(createUserDto));

        //Assert
        Assert.Equal(nameof(User.Name), result.ParamName);
        mockDataProvider.Verify(dataProvider => dataProvider.SaveChangesAsync(), Times.Never);
    }
    [Fact]
    public async Task CreateUser_PhoneIsEmpty_ReturnsError()
    {
        var createUserDto = new Faker<UserDto>()
        .RuleFor(u => u.Email, f => f.Internet.Email())
        .RuleFor(u => u.Name, f => f.Name.FirstName())
        .RuleFor(u => u.Telephone, f => "")
        .Generate();

        var mockDataProvider = new Mock<IUsersDataProvider>();

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.CreateAsync(createUserDto));

        //Assert
        Assert.Equal(nameof(User.Telephone), result.ParamName);
        mockDataProvider.Verify(dataProvider => dataProvider.SaveChangesAsync(), Times.Never);
    }
    [Fact]
    public async Task GetById_UserIsFindByCorrectId_ReturnsUser()
    {
        //Arrange
        var exceptedRole = "Client";
        var exceptedReturnUser = new Faker<User>()
        .RuleFor(u => u.Id, f => expectedId)
        .RuleFor(u => u.Email, f => f.Internet.Email())
        .RuleFor(u => u.Name, f => f.Name.FirstName())
        .RuleFor(u => u.Telephone, f => f.Phone.PhoneNumber())
        .RuleFor(u => u.Role, f => exceptedRole)
        .Generate();

        var mockDataProvider = new Mock<IUsersDataProvider>();

        mockDataProvider.Setup(dataProvider => dataProvider.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(exceptedReturnUser);

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await userService.GetByIdAsync(expectedId);

        //Assert
        Assert.Equal(exceptedReturnUser.Id, result.Id);
        Assert.Equal(exceptedReturnUser.Name, result.Name);
        Assert.Equal(exceptedReturnUser.Email, result.Email);
        Assert.Equal(exceptedReturnUser.Telephone, result.Telephone);
        Assert.Equal(exceptedReturnUser.Role, result.Role);
    }

    [Fact]
    public async Task GetById_UserIsNotFoundByCorrectId_ReturnsError()
    {
        //Arrange
        var mockDataProvider = new Mock<IUsersDataProvider>();

        mockDataProvider.Setup(dataProvider => dataProvider.GetByIdAsync(expectedId)).ReturnsAsync((User)null);

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.GetByIdAsync(expectedId));

        //Assert
        Assert.Equal(nameof(User), result.ParamName);
    }

    [Fact]
    public async Task GetById_IdIsEmpty_ReturnsError()
    {
        //Arrange
        Guid searchId = Guid.Empty;

        var mockDataProvider = new Mock<IUsersDataProvider>();

        //mock setup
        mockDataProvider.Setup(dataProvider => dataProvider.GetByIdAsync(searchId)).ReturnsAsync((User)null);

        var mockObject = mockDataProvider.Object;

        var userService = new UsersService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await userService.GetByIdAsync(searchId));

        //Assert
        Assert.Equal(nameof(CommonMessages.IdIsEmpty), result.ParamName);
    }
}
