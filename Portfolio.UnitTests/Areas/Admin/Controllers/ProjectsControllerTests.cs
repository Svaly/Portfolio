using NUnit.Framework;
using Portfolio.WebUI.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using Portfolio.Domain;
using Portfolio.Domain.Abstract;
using System.Web.Mvc;
namespace Portfolio.WebUI.Areas.Admin.Controllers.Tests
{
    [TestFixture()]
    public class ProjectsControllerTests
    {
        private DateTime testedDateTime = DateTime.Now;     

        [Test()]
        public void AllProjects_ReturnsViewResultContainingAllProjects()
        {
            IProjectRepository fakeProjectRepository = CreateFakeRepository();

            ProjectsController controller = new ProjectsController(fakeProjectRepository);
            var result = controller.AllProjects();       
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = (ViewResult) result;

            Projects[] resultModel = ((IEnumerable<Projects>)viewResult.ViewData.Model).ToArray();

            Assert.AreEqual(resultModel.Length, 2);
            Assert.AreEqual("tytul 1", resultModel[0].Title);
            Assert.AreEqual("tytul 2", resultModel[1].Title);
        }

        [Test()]
        public void CreateTest_ReturnsCreateViewWithProjectModel()
        {
            IProjectRepository fakeProjectRepository = Substitute.For<IProjectRepository>();

            ProjectsController controller = new ProjectsController(fakeProjectRepository);
            var result = controller.Create();
            Assert.IsInstanceOf<ViewResult>(result);

            ViewResult viewResult = (ViewResult)result;
            Assert.AreEqual(viewResult.ViewName,"Create");
            Assert.IsInstanceOf<Projects>(viewResult.ViewData.Model);

        }

        [Test()]
        public void SaveTest()
        {
            IProjectRepository fakeProjectRepository = Substitute.For<IProjectRepository>();

            ProjectsController controller = new ProjectsController(fakeProjectRepository);

              Projects p1 = new Projects
                {
                    Id = 1,
                    Title = "tytul 1",
                    Category = "it",
                    Description = "opis 1",
                    RealizationDate = testedDateTime,
                    AddedDate = testedDateTime,
                    LastEditDate = testedDateTime,
                    Active = "Aktywny"
                };

            var result = controller.Save(p1);
            fakeProjectRepository.ReceivedWithAnyArgs(1);
           

        }

        [Test()]
        public void EditProjectTest()
        {

        }

        [Test()]
        public void ActivateTest()
        {

        }

        [Test()]
        public void DeactivateTest()
        {

        }

        public IProjectRepository CreateFakeRepository()
        {
            IProjectRepository fakeProjectRepository = Substitute.For<IProjectRepository>();

            var images1 = new List<Images>()
            {
                new Images() { Id = 1, Name = "img1 ", ProjectId = 1, ThumbnailName = "immg1_thumb" },
                new Images() { Id = 2, Name = "img2 ", ProjectId = 1, ThumbnailName = "immg2_thumb" },
                new Images() { Id = 3, Name = "img3 ", ProjectId = 1, ThumbnailName = "immg3_thumb" }
            };

            var p1 = new Projects
            {
                Id = 1,
                Title = "tytul 1",
                Category = "it",
                Description = "opis 1",
                RealizationDate = testedDateTime,
                AddedDate = testedDateTime,
                LastEditDate = testedDateTime,
                Active = "Aktywny",
                Images = images1
            };

            var images2 = new List<Images>()
            {
                new Images() { Id = 1, Name = "img1 ", ProjectId = 2, ThumbnailName = "immg1_thumb" },
                new Images() { Id = 2, Name = "img2 ", ProjectId = 2, ThumbnailName = "immg2_thumb" },
                new Images() { Id = 3, Name = "img3 ", ProjectId = 2, ThumbnailName = "immg3_thumb" }
            };

            var p2 = new Projects
            {
                Id = 2,
                Title = "tytul 2",
                Category = "it",
                Description = "opis 2",
                RealizationDate = testedDateTime,
                AddedDate = testedDateTime,
                LastEditDate = testedDateTime,
                Active = "Aktywny",
                Images = images1
            };

            fakeProjectRepository.Projects.Returns(
                new List<Projects>() { p1, p2 });

            return fakeProjectRepository;
        }
    }
}