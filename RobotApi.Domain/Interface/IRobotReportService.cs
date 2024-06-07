namespace RobotApi.Domain.Interface
{
    /// <summary>
    /// Represents the interface for a robot report service.
    /// </summary>
    public interface IRobotReportService
    {
        /// <summary>
        /// Generates a report for the robot.
        /// </summary>
        /// <returns>The generated report.</returns>
        string Report();
    }
}
