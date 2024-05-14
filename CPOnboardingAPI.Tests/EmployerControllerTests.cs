using AutoMapper;
using CPOnboardingAPI.Controllers;
using CPOnboardingAPI.Data;
using CPOnboardingAPI.Dtos.Requests;
using CPOnboardingAPI.Dtos.Responses;
using CPOnboardingAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CPOnboardingAPI.Tests
{
    public class EmployerControllerTests
    {

        private EmployeerController _employerController;
        private readonly Mock<IRepository> _mockRepo;
        private readonly Mock<IMapper> _mapperMock;

        public EmployerControllerTests()
        {
            _mockRepo = new Mock<IRepository>();
            _mapperMock = new Mock<IMapper>();

            _employerController = new EmployeerController(_mockRepo.Object, _mapperMock.Object);
        }

        [Fact]
        public void Test_Controller_Init_Returns_CorrectObject()
        {
            Assert.NotNull(_employerController);
        }

        [Fact]
        public async void Test_GetQuestionTypes_Returns_Correct_Items()
        {
            var result = await _employerController.GetQuestionTypes();
            Assert.NotNull(result);
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var response = Assert.IsType<List<string>>(okResult.Value);
            Assert.NotNull(response);
        }

        [Fact]
        public async void Test_CreateTemplate_Returns_Correct_Object()
        {
            var request = new ApplicationTemplateRequest();
            var mappedRequest = new ApplicationTemplate();

            _mapperMock.Setup(x => x.Map<ApplicationTemplate>(request)).Returns(mappedRequest);

            var createdTemplate = new ApplicationTemplate();
            _mockRepo.Setup(x => x.CreateTemplate(mappedRequest)).ReturnsAsync(createdTemplate);

            var expectedResponse = new ApplicationTemplateResponse();
            _mapperMock.Setup(x => x.Map<ApplicationTemplateResponse>(createdTemplate)).Returns(expectedResponse);

            var controller = new EmployeerController(_mockRepo.Object, _mapperMock.Object);
            var response = await controller.CreateTemplate(request);
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var responseValue = Assert.IsType<ApplicationTemplateResponse>(okResult.Value);
            Assert.Equal(expectedResponse, responseValue);
        }

        [Fact]
        public async Task Test_GetAllTemplates_Returns_Correct_Items()
        {
            var templates = new List<ApplicationTemplate>();
            _mockRepo.Setup(x => x.GetAllTemplates()).ReturnsAsync(templates);

            var expectedResponse = new List<ApplicationTemplateResponse>();
            _mapperMock.Setup(x => x.Map<IEnumerable<ApplicationTemplateResponse>>(templates)).Returns(expectedResponse);

            var controller = new EmployeerController(_mockRepo.Object, _mapperMock.Object);
            var response = await controller.GetAllTemplates();
            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var responseValue = Assert.IsAssignableFrom<IEnumerable<ApplicationTemplateResponse>>(okResult.Value);
            Assert.Equal(expectedResponse, responseValue);
        }

        [Fact]
        public async Task Test_GetTemplate_Returns_Correct_Item()
        {
            var template = new ApplicationTemplate();
            _mockRepo.Setup(x => x.GetTemplateById("myId")).ReturnsAsync(template);

            var expectedResponse = new ApplicationTemplateResponse();
            _mapperMock.Setup(x => x.Map<ApplicationTemplateResponse>(template)).Returns(expectedResponse);
            var controller = new EmployeerController(_mockRepo.Object, _mapperMock.Object);
            var response = await controller.GetTemplate("myId");

            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var responseValue = Assert.IsType<ApplicationTemplateResponse>(okResult.Value);
            Assert.Equal(expectedResponse, responseValue);
        }
        [Fact]
        public async Task Test_UpdateTemplate_Returns_Correct_Item()
        {
            var request = new ApplicationTemplateRequest();
            var mappedRequest = new ApplicationTemplate();

            _mapperMock.Setup(x => x.Map<ApplicationTemplate>(request)).Returns(mappedRequest);
            var updatedTemplate = new ApplicationTemplate();
            _mockRepo.Setup(x => x.UpdateTemplate("myId", mappedRequest)).ReturnsAsync(updatedTemplate);
            var expectedResponse = new ApplicationTemplateResponse();
            _mapperMock.Setup(x => x.Map<ApplicationTemplateResponse>(updatedTemplate)).Returns(expectedResponse);

            var controller = new EmployeerController(_mockRepo.Object, _mapperMock.Object);
            var response = await controller.UpdateTemplate("myId", request);

            var okResult = Assert.IsType<OkObjectResult>(response.Result);
            var responseValue = Assert.IsType<ApplicationTemplateResponse>(okResult.Value);
            Assert.Equal(expectedResponse, responseValue);
        }

        [Fact]
        public async Task Test_DeleteTemplate_Returns_NoContent()
        {
            var controller = new EmployeerController(_mockRepo.Object, _mapperMock.Object);
            var response = await controller.DeleteTemplate("myId");
            Assert.IsType<NoContentResult>(response);
        }


    }
}
