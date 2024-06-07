namespace RobotApi.API.Tests.Controllers
{
    public class RobotControllerTests
    {
        private readonly Mock<IRobotMoveService> _mockRobotMoveService;
        private readonly Mock<IRobotPlaceService> _mockRobotPlaceService;
        private readonly Mock<IRobotRotateService> _mockRobotRotateService;
        private readonly Mock<IRobotReportService> _mockRobotReportService;
        private readonly RobotController _robotController;

        public RobotControllerTests()
        {
            _mockRobotMoveService = new Mock<IRobotMoveService>();
            _mockRobotPlaceService = new Mock<IRobotPlaceService>();
            _mockRobotRotateService = new Mock<IRobotRotateService>();
            _mockRobotReportService = new Mock<IRobotReportService>();

            _robotController = new RobotController(
                _mockRobotMoveService.Object,
                _mockRobotPlaceService.Object,
                _mockRobotRotateService.Object,
                _mockRobotReportService.Object
            );
        }

        [Fact]
        public void Move_ShouldCallMoveServiceAndReturnOkResult()
        {
            // Arrange
            var moveResponse = "Move successful";
            _mockRobotMoveService.Setup(x => x.Move()).Returns(moveResponse);

            // Act
            var result = _robotController.Move();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(moveResponse, okResult.Value);
        }

        [Fact]
        public void Move_ShouldReturnBadRequestResult_WhenMoveServiceReturnsNull()
        {
            // Arrange
            _mockRobotMoveService.Setup(x => x.Move()).Returns((string)null);

            // Act
            var result = _robotController.Move();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal("Check Request", badRequestResult.Value);
        }

        [Fact]
        public void Place_ShouldCallPlaceServiceAndReturnOkResult()
        {
            // Arrange
            var placeRequest = new PlaceRequest
            {
                X = 1,
                Y = 2,
                DirectionFacing = Direction.NORTH,
                TableSize = 5
            };

            // Act
            var result = _robotController.Place(placeRequest);

            // Assert
            Assert.IsType<OkResult>(result);
            _mockRobotPlaceService.Verify(x => x.Place(placeRequest.X, placeRequest.Y, placeRequest.DirectionFacing, placeRequest.TableSize), Times.Once);
        }

        [Fact]
        public void Left_ShouldCallLeftServiceAndReturnOkResult()
        {
            // Arrange
            var leftResponse = "Left rotation successful";
            _mockRobotRotateService.Setup(x => x.Left()).Returns(leftResponse);

            // Act
            var result = _robotController.Left();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(leftResponse, okResult.Value);
        }

        [Fact]
        public void Left_ShouldReturnBadRequestResult_WhenLeftServiceReturnsNull()
        {
            // Arrange
            _mockRobotRotateService.Setup(x => x.Left()).Returns((string)null);

            // Act
            var result = _robotController.Left();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal("Check Request", badRequestResult.Value);
        }

        [Fact]
        public void Right_ShouldCallRightServiceAndReturnOkResult()
        {
            // Arrange
            var rightResponse = "Right rotation successful";
            _mockRobotRotateService.Setup(x => x.Right()).Returns(rightResponse);

            // Act
            var result = _robotController.Right();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(rightResponse, okResult.Value);
        }

        [Fact]
        public void Right_ShouldReturnBadRequestResult_WhenRightServiceReturnsNull()
        {
            // Arrange
            _mockRobotRotateService.Setup(x => x.Right()).Returns((string)null);

            // Act
            var result = _robotController.Right();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal("Check Request", badRequestResult.Value);
        }

        [Fact]
        public void Report_ShouldCallReportServiceAndReturnOkResult()
        {
            // Arrange
            var report = "Robot is at position (1, 2) facing North";
            _mockRobotReportService.Setup(x => x.Report()).Returns(report);

            // Act
            var result = _robotController.Report();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(report, okResult.Value);
        }

        [Fact]
        public void Report_ShouldReturnBadRequestResult_WhenReportServiceReturnsNull()
        {
            // Arrange
            _mockRobotReportService.Setup(x => x.Report()).Returns((string)null);

            // Act
            var result = _robotController.Report();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
            var badRequestResult = (BadRequestObjectResult)result;
            Assert.Equal("Robot is not placed on the table", badRequestResult.Value);
        }
    }
}
