using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TravelBlog.Controllers;
using TravelBlog.Models;
using TravelBlog.Tests.ModelTests;
using Xunit;

namespace TravelBlog.Tests
{
    public class SuggestionsControllerTest : IDisposable
    {
        EFSuggestionRepository db = new EFSuggestionRepository(new TestDbContext());

        [Fact]
        public void Get_ViewIndex_Test()
        {
            //Arrange
            SuggestionsController controller = new SuggestionsController(db);

            //Act
            IActionResult result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void DB_ViewIndex_Test()
        {
            // Arrange
            SuggestionsController controller = new SuggestionsController(db);
            Suggestion testSuggestion = new Suggestion();
            testSuggestion.Description = "So quiet.";
            
            Location testLocation = new Location();
            testLocation.LocationName = "New Mexico";
            db.Save(testLocation);

            // Act
            controller.Create(testSuggestion, testLocation.LocationId);
            ViewResult indexView = new SuggestionsController().Index() as ViewResult;
            IEnumerable<Suggestion> collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Suggestion>;

            // Assert
            Assert.Contains(testSuggestion, collection);
        }

        [Fact]
        public void Get_ViewCreate_Test()
        {
            //Arrange
            Location location = new Location();
            location.LocationName = "Testland";
            db.Save(location);
            SuggestionsController controller = new SuggestionsController(db);

            //Act
            IActionResult result = controller.Create(location.LocationId);

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
    }

}
