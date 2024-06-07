namespace RobotApi.Domain.Interface
{
    /// <summary>
    /// Represents the interface for a robot move service.
    /// </summary>
    public interface IRobotMoveService
    {
        /// <summary>
        /// Moves the robot.
        /// </summary>
        string Move();
    }
}
