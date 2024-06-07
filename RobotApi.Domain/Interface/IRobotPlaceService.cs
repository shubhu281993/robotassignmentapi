using RobotApi.Common.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotApi.Domain.Interface
{
    /// <summary>
    /// Represents the interface for placing a robot.
    /// </summary>
    public interface IRobotPlaceService
    {
        /// <summary>
        /// Places the robot at the specified coordinates and direction.
        /// </summary>
        /// <param name="xDistance">The x-coordinate distance.</param>
        /// <param name="yDistance">The y-coordinate distance.</param>
        /// <param name="direction">The direction the robot is facing.</param>
        /// <param name="tableSize">The table size.</param>
        void Place(int xDistance, int yDistance, Direction direction, int tableSize);
    }
}
