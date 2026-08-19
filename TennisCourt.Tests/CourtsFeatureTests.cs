using Bogus;
using Moq;
using TennisCourt.Features.Courts.Data;
using TennisCourt.Features.Courts.Models;
using TennisCourt.Features.Courts.Services;
using TennisCourt.Infrastructure.Constants;
using TennisCourt.Infrastructure.Entities;

namespace TennisCourt.Tests;

public class CourtsFeatureTests
{

    private Guid expectedId = Guid.NewGuid();

    [Fact]
    public async Task CreateCourt_AllFieldsValid_ReturnId()
    {
        //Arrange
        var createCourtDto = new Faker<CreateCourtDto>()
        .RuleFor(court => court.Street, f => f.Address.StreetName())
        .RuleFor(court => court.Name, f => f.Company.CompanyName())
        .RuleFor(court => court.SurfaceType, f => "Hard")
        .RuleFor(court => court.IsIndoor, f => true)
        .Generate();

        var mockDataProvider = new Mock<ICourtsDataProvider>();

        mockDataProvider.Setup(dataProvider => dataProvider.CreateAsync(It.IsAny<Court>())).ReturnsAsync(expectedId);

        var mockObject = mockDataProvider.Object;

        var courtsService = new CourtsService(mockObject);

        //Act
        var result = await courtsService.CreateAsync(createCourtDto);

        //Assert
        Assert.Equal(expectedId, result);
    }
    [Fact]
    public async Task CreateCourt_StreetIsEmpty_ReturnsError()
    {
        //Arrange
        var createCourtDto = new Faker<CreateCourtDto>()
        .RuleFor(court => court.Street, f => "")
        .Generate();

        var mockDataProvider = new Mock<ICourtsDataProvider>();

        var mockObject = mockDataProvider.Object;

        var courtsService = new CourtsService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await courtsService.CreateAsync(createCourtDto));

        //Assert
        Assert.Equal(nameof(Court.Street), result.ParamName);
    }
    [Fact]
    public async Task CreateCourt_NameIsEmpty_ReturnsError()
    {
        //Arrange
        var createCourtDto = new Faker<CreateCourtDto>()
        .RuleFor(court => court.Street, f => f.Address.StreetName())
        .RuleFor(court => court.Name, f => "")
        .Generate();

        var mockDataProvider = new Mock<ICourtsDataProvider>();

        var mockObject = mockDataProvider.Object;

        var courtsService = new CourtsService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await courtsService.CreateAsync(createCourtDto));

        //Assert
        Assert.Equal(nameof(Court.Name), result.ParamName);
    }

    [Fact]
    public async Task CreateCourt_SurfaceTypeIsEmpty_ReturnsError()
    {
        //Arrange
        var createCourtDto = new Faker<CreateCourtDto>()
        .RuleFor(court => court.Street, f => f.Address.StreetName())
        .RuleFor(court => court.Name, f => f.Company.CompanyName())
        .RuleFor(court => court.SurfaceType, f => "")
        .Generate();

        var mockDataProvider = new Mock<ICourtsDataProvider>();

        var mockObject = mockDataProvider.Object;

        var courtsService = new CourtsService(mockObject);

        //Act
        var result = await Assert.ThrowsAsync<ArgumentNullException>(async () => await courtsService.CreateAsync(createCourtDto));

        //Assert
        Assert.Equal(nameof(Court.SurfaceType), result.ParamName);
    }

    [Fact]
    public async Task GetAll_ReturnCourts()
    {
        //Arrange
        var courts = new Faker<Court>().Generate(4);

        var mockDataProvider = new Mock<ICourtsDataProvider>();

        mockDataProvider.Setup(dataProvider => dataProvider.GetAllAsync()).ReturnsAsync(courts);

        var mockObject = mockDataProvider.Object;

        var courtsService = new CourtsService(mockObject);

        //Act
        var result = await courtsService.GetAllAsync();

        //Assert
        Assert.Equal(courts.Count, result.Count());
    }

    [Fact]
    public async Task GetAll_ReturnEmptyList()
    {
        //Arrange
        var courts = new Faker<Court>().Generate(0);

        var mockDataProvider = new Mock<ICourtsDataProvider>();

        mockDataProvider.Setup(dataProvider => dataProvider.GetAllAsync()).ReturnsAsync(courts);

        var mockObject = mockDataProvider.Object;

        var courtsService = new CourtsService(mockObject);

        //Act
        var result = await courtsService.GetAllAsync();

        //Assert
        Assert.Equal(courts.Count, result.Count());
    }

}