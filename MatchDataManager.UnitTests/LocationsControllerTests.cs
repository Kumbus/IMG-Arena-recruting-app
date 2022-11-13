using MatchDataManager.Api.Controllers;
using MatchDataManager.Domain.Entities;
using MatchDataManager.Domain.Exceptions;
using MatchDataManager.Services.DTO;
using MatchDataManager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace MatchDataManager.UnitTests
{
    public class LocationsControllerTests
    {
        private readonly Mock<IServiceManager> _mockServiceManager;
        private readonly LocationsController _controller;
        public LocationsControllerTests()
        {
            _mockServiceManager = new Mock<IServiceManager>();
            _controller = new LocationsController(_mockServiceManager.Object);
            
        }

        [Theory]
        [MemberData(nameof(LocationsControllerTestData.GetAllData), MemberType = typeof(LocationsControllerTestData))]
        public async Task Get_ActionExecutes_ReturnsAllLocations(IEnumerable<LocationDTO> locationsDTOs, int expectedLength)
        {
            _mockServiceManager.Setup(x => x.LocationService.GetAllLocationsAsync(CancellationToken.None)).
                Returns(Task.FromResult(locationsDTOs));

            var actionResult = await _controller.Get(CancellationToken.None);
            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);

            IEnumerable<LocationDTO> locationsResult = (IEnumerable<LocationDTO>)result.Value;
            Assert.NotNull(locationsResult);

            Assert.Equal(expectedLength, locationsResult.Count());
        }

        [Theory]
        [MemberData(nameof(LocationsControllerTestData.GetLocationByIdData), MemberType = typeof(LocationsControllerTestData))]
        public async Task GetlocationById_ActionExecutes_ReturnsLocationWithProvidedId(Guid id, LocationDTO location, LocationDTO expectedLocation)
        {
            _mockServiceManager.Setup(x => x.LocationService.GetLocationByIdAsync(id, CancellationToken.None)).
                Returns(Task.FromResult(location));

            var actionResult = await _controller.GetById(id, CancellationToken.None);
            Assert.NotNull(actionResult);

            var result = actionResult.Result as OkObjectResult;
            Assert.NotNull(result);

            LocationDTO locationResult = (LocationDTO)result.Value;
            Assert.NotNull(locationResult);

            Assert.Equal(expectedLocation.Name, locationResult.Name);
            Assert.Equal(expectedLocation.City, locationResult.City);
            Assert.Equal(expectedLocation.Id, locationResult.Id);
        }

        [Theory]
        [MemberData(nameof(LocationsControllerTestData.AddLocationData), MemberType = typeof(LocationsControllerTestData))]
        public async Task AddLocation_ActionExecutes_AddsNewLocationToDatabase(LocationForCreationDTO locationForCreation, LocationDTO location, LocationDTO expectedLocation)
        {
            _mockServiceManager.Setup(x => x.LocationService.AddAsync(locationForCreation, CancellationToken.None)).
                Returns(Task.FromResult(location));

            var actionResult = await _controller.AddLocation(locationForCreation);
            Assert.NotNull(actionResult);

            var result = actionResult.Result as CreatedAtActionResult;
            Assert.NotNull(result);

            LocationForCreationDTO locationResult = (LocationForCreationDTO)result.Value;
            Assert.NotNull(locationResult);

            Assert.Equal(expectedLocation.Name, locationResult.Name);
            Assert.Equal(expectedLocation.City, locationResult.City);
            Assert.Equal(expectedLocation.Id, result.RouteValues.Values.First());
        }


    }

}