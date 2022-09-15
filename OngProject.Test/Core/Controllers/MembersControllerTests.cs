using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OngProject.Controllers;
using OngProject.Core.Interfaces;
using OngProject.Core.Models.DTOs.PagedListDTO;
using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OngProject.Test.Core.Controllers
{
    public class MembersControllerTests
    {
        [Fact]
        public async void GetAllMembers_OnSuccess_ReturnsStatusCode200()
        {
            // Arrange
            var membersBusinessMock = new Mock<IMembersBusiness>();

            membersBusinessMock
                .Setup(m => m.GetAllMembers())
                .Returns(Task.FromResult<IQueryable<MembersDTO>>(new List<MembersDTO>() { new MembersDTO { Description = "test" } }.AsQueryable()));

            var sut = new MembersController(membersBusinessMock.Object);
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = await sut.GetAllMembers(1, 1);

            // Assert
            result
                .Should()
                .BeOfType<OkObjectResult>();
        }

        [Fact]
        public async void GetAllMembers_OnSuccess_ReturnsListOfMembersDTO()
        {
            // Arrange
            var membersBusinessMock = new Mock<IMembersBusiness>();

            membersBusinessMock
                .Setup(m => m.GetAllMembers())
                .Returns(Task.FromResult<IQueryable<MembersDTO>>(new List<MembersDTO>() { new MembersDTO { Description = "test" } }.AsQueryable()));

            var sut = new MembersController(membersBusinessMock.Object);
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = (OkObjectResult)await sut.GetAllMembers(1, 1);

            // Assert
            result
                .Value
                .Should()
                .BeOfType<PagedListDTO<MembersDTO>>();
        }


        // Test in which there is no Members in database.
        [Fact]
        public async void GetAllMembers_OnFail_ReturnsStatusCode404()
        {
            // Arrange
            var membersBusinessMock = new Mock<IMembersBusiness>();

            membersBusinessMock
                .Setup(m => m.GetAllMembers())
                .Returns(Task.FromResult<IQueryable<MembersDTO>>(null));

            var sut = new MembersController(membersBusinessMock.Object);
            sut.ControllerContext = new ControllerContext();
            sut.ControllerContext.HttpContext = new DefaultHttpContext();

            // Act
            var result = await sut.GetAllMembers(1, 1);

            // Assert
            result
                .Should()
                .BeOfType<NotFoundResult>();
        }

        [Fact]
        public async void CreateMember_OnSuccess_ReturnsStatisCode200()
        {

        }
    }
}
