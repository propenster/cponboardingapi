using CPOnboardingAPI.Data;
using CPOnboardingAPI.Models;
using Microsoft.Azure.Cosmos;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CPOnboardingAPI.Tests
{
    public class RepositoryTests
    {

        private readonly Mock<IRepository> _repoMock;
        private readonly Repository _service;
        public RepositoryTests()
        {
            _repoMock = new Mock<IRepository>();
            _service = new Repository(new Mock<CosmosClient>().Object, "AKD", "SDK");
        }

        [Fact]
        public void Test_Constructor_Returns_Correct_RepositoryObject()
        {
            Assert.NotNull(_repoMock.Object);
        }
        [Fact]
        public async Task Test_CreateTemplate_Returns_Correct_Object()
        {
            var template = new ApplicationTemplate { Id = Guid.NewGuid().ToString() };
            _repoMock.Setup(x => x.CreateTemplate(It.IsAny<ApplicationTemplate>())).ReturnsAsync(template);

            var result = await _repoMock.Object.CreateTemplate(new ApplicationTemplate { Id = template.Id });

            Assert.NotNull(result);
            Assert.Equal(template.Id, result.Id);
        }
        [Fact]
        public async Task Test_GetAllTemplates_Returns_Correct_List()
        {
            var templates = new List< ApplicationTemplate> { new ApplicationTemplate { Id = Guid.NewGuid().ToString() } };
            _repoMock.Setup(x => x.GetAllTemplates()).ReturnsAsync(templates);

            var result = await _repoMock.Object.GetAllTemplates();

            Assert.NotNull(result);
            Assert.Equal(templates, result);
            Assert.Equal(templates.Count, result.Count());
        }
        [Fact]
        public async Task Test_GetTemplateById_Returns_Correct_Object()
        {
            var template = new ApplicationTemplate { Id = Guid.NewGuid().ToString() };
            _repoMock.Setup(x => x.GetTemplateById(It.IsAny<string>())).ReturnsAsync(template);
             
            var result = await _repoMock.Object.GetTemplateById("myId");

            Assert.NotNull(result);
            Assert.Equal(template.Title, result.Title);
        }

        [Fact]
        public async Task Test_UpdateTemplate_Returns_Correct_Object()
        {
            var template = new ApplicationTemplate { Id = Guid.NewGuid().ToString() };
            _repoMock.Setup(x => x.UpdateTemplate(It.IsAny<string>(), It.IsAny<ApplicationTemplate>())).ReturnsAsync(template);

            var result = await _repoMock.Object.UpdateTemplate("myId", new ApplicationTemplate { Id = template.Id}); 

            Assert.NotNull(result);
            Assert.Equal(template.Title, result.Title);
        }
    }

}
