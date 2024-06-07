using RobotApi.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApi.Domain.Interface
{
    /// <summary>
    /// Represents a service for rotating a robot.
    /// </summary>
    public interface IRobotRotateService
    {
        /// <summary>
        /// Rotates the robot to the left.
        /// </summary>
        string Left();

        /// <summary>
        /// Rotates the robot to the right.
        /// </summary>
        string Right();
    }
}
