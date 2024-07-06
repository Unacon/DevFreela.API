using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandsHandlerTests
    {
        [Fact]
        public async Task ThreeProjjectExist_Executed_ReturnThreeProjectViewModels()
        {
            //Arrange
            List<Project> projects = new List<Project>()
            {
                new Project("Titulo1","Descrição 01",1,2,10000),
                new Project("Titulo2","Descrição 02",1,3,20000),
                new Project("Titulo2","Descrição 02",1,4,30000)
            };

            IProjectRepository projectRepository = Substitute.For<IProjectRepository>();

            projectRepository.GetAllAsync().Returns(projects);

            GetAllProjectsQuery getAllProjectQuery = new GetAllProjectsQuery();
            GetAllProjectsQueryHandler getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepository);

            //Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectQuery, new CancellationToken());

            //Assert
            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);

            await projectRepository.Received().GetAllAsync();
        }
    }
}
