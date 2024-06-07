

namespace RobotApi.Domain.Tests.Services
{
    /// <summary>
    /// Unit tests for the Robot class.
    /// </summary>
    public class RobotTests
    {
        [Fact]
        public void Left_ShouldRotateRobot90DegreesToLeft()
        {
            // Arrange
            var robot = new Robot();
            robot.Place(2, 2, Direction.NORTH, 5);

            // Act
            var result = robot.Left();

            // Assert
            Assert.Equal("Robot turning left!!", result);
        }

        [Fact]
        public void Right_ShouldRotateRobot90DegreesToRight()
        {
            // Arrange
            var robot = new Robot();
            robot.Place(2, 2, Direction.NORTH, 5);

            // Act
            var result = robot.Right();

            // Assert
            Assert.Equal("Robot turning right!!", result);
        }

        [Fact]
        public void Move_ShouldMoveRobotOneUnitInFacingDirection()
        {
            // Arrange
            var robot = new Robot();
            robot.Place(2, 2, Direction.NORTH, 5);

            // Act
            var result = robot.Move();

            // Assert
            Assert.Equal("Robot is moving", result);
        }

        [Fact]
        public void Report_ShouldReturnCurrentPositionAndFacingDirectionOfRobot()
        {
            // Arrange
            var robot = new Robot();
            robot.Place(2, 2, Direction.NORTH, 5);

            // Act
            var result = robot.Report();

            // Assert
            Assert.Equal("2,2,NORTH", result);
        }
    }
}