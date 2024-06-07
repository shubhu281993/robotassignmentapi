namespace RobotApi.API.Controllers
{
    /// <summary>
    /// Controller for handling robot movements and reporting.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class RobotController : ControllerBase
    {
        private readonly IRobotMoveService _robotMoveService;
        private readonly IRobotPlaceService _robotPlaceService;
        private readonly IRobotRotateService _robotRotateService;
        private readonly IRobotReportService _robotReportService;

        public RobotController(IRobotMoveService robotMoveService, IRobotPlaceService robotPlaceService, IRobotRotateService robotRotateService, IRobotReportService robotReportService)
        {
            _robotMoveService = robotMoveService;
            _robotPlaceService = robotPlaceService;
            _robotRotateService = robotRotateService;
            _robotReportService = robotReportService;
        }

        /// <summary>
        /// Moves the robot one step forward in the current direction.
        /// </summary>
        [HttpPost("move")]
        public IActionResult Move()
        {
            var moveResponse = _robotMoveService.Move();
            if (string.IsNullOrEmpty(moveResponse)) return BadRequest("Check Request");
            return Ok(moveResponse);
        }

        /// <summary>
        /// Places the robot on the table at the specified coordinates and direction.
        /// </summary>
        /// <param name="request">The place request containing the coordinates and direction.</param>
        [HttpPost("place")]
        public IActionResult Place([FromBody] PlaceRequest request)
        {
            _robotPlaceService.Place(request.X, request.Y, request.DirectionFacing, request.TableSize);
            return Ok();
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the left.
        /// </summary>
        [HttpPost("left")]
        public IActionResult Left()
        {
            var leftResponse = _robotRotateService.Left();
            if (string.IsNullOrEmpty(leftResponse)) return BadRequest("Check Request");
            return Ok(leftResponse);
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the right.
        /// </summary>
        [HttpPost("right")]
        public IActionResult Right()
        {
            var rightResponse = _robotRotateService.Right();
            if (string.IsNullOrEmpty(rightResponse)) return BadRequest("Check Request");
            return Ok(rightResponse);
        }

        /// <summary>
        /// Retrieves the current position and direction of the robot.
        /// </summary>
        /// <returns>The robot's position and direction as a string.</returns>
        [HttpGet("report")]
        public IActionResult Report()
        {
            var report = _robotReportService.Report();
            if (string.IsNullOrEmpty(report))
            {
                return BadRequest("Robot is not placed on the table");
            }
            return Ok(report);
        }
    }
}
