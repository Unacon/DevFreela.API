using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDataIsOk_Executed_ReturnProjectId()
        {
            //Arrange
            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();

            CreateProjectCommand createProjectCommand = new CreateProjectCommand()
            {
                Title = "Title",
                Description = "Description",
                IdClient = 1,
                IdFreelancer = 1,
                TotalCost = 500
            };

            CreateProjectHandler createProjectCommandHandler = new CreateProjectHandler(projectRepository);
            //Act
            int id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert
            //Assert.True(id > 1);

            await projectRepository.Received().CreateProjectAsync(Arg.Any<Project>());
        }
    }
}
