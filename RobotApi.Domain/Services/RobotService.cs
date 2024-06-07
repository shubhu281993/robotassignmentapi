
namespace RobotApi.Domain.Services
{
    /// <summary>
    /// Represents a service for controlling a robot.
    /// </summary>
    public class RobotService : IRobotPlaceService, IRobotMoveService, IRobotRotateService, IRobotReportService
    {
        private readonly Robot _robot;

        public RobotService(Robot robot)
        {
            _robot = robot;
        }

        /// <summary>
        /// Rotates the robot to the left.
        /// </summary>
        public string Left()
        {
            return _robot.Left();
        }

        /// <summary>
        /// Moves the robot forward.
        /// </summary>
        public string Move()
        {
           return _robot.Move();
        }

        /// <summary>
        /// Places the robot on the table at the specified position and direction.
        /// </summary>
        /// <param name="xDistance">The x-coordinate distance from the origin.</param>
        /// <param name="yDistance">The y-coordinate distance from the origin.</param>
        /// <param name="direction">The direction the robot is facing.</param>
        /// <param name="tableSize">The size of the table.</param>
        public void Place(int xDistance, int yDistance, Direction direction, int tableSize)
        {
            _robot.Place(xDistance, yDistance, direction, tableSize);
        }

        /// <summary>
        /// Rotates the robot to the right.
        /// </summary>
        public string Right()
        {
            return _robot.Right();
        }

        /// <summary>
        /// Reports the current position and direction of the robot.
        /// </summary>
        /// <returns>A string representation of the robot's position and direction.</returns>
        public string Report()
        {
            return _robot.Report();
        }
    }
}
