using u23707438_HW01_API.Controllers;
using u23707438_HW01_API.Data;
using u23707438_HW01_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace u23707438_HW01_API.Tests
{
    public class EventControllerTests
    {
        private AppDbContext GetInMemoryDbContext()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var context = new AppDbContext(options);

            context.Events.AddRange(
                new Event { EventId = 1, EventTitle = "Tech Workshop", Location = "Lab A", TicketPrice = "$50" },
                new Event { EventId = 2, EventTitle = "Music Festival", Location = "Main Hall", TicketPrice = "$120" }
            );
            context.SaveChanges();

            return context;
        }

        [Fact]
        public async Task GetAllEvents_ReturnsOkAndNotNull()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new EventController(context);

            // Act
            var result = await controller.GetAllEvents();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }

        [Fact]
        public async Task GetEventById_ReturnsOkAndNotNull()
        {
            // Arrange
            var context = GetInMemoryDbContext();
            var controller = new EventController(context);

            // Act
            var result = await controller.GetEventById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }
    }
}