
namespace RobotApi.Domain.Services
{
    public class Robot
    {

        private int? x;
        private int? y;
        public Direction? directionFacing;
        private int tableSize;

        public Robot()
        {
            this.tableSize = 5;
        }

        public void SetTableSize(int size)
        {
            this.tableSize = size;
        }
        /// <summary>
        /// Rotates the robot 90 degrees to the left.
        /// </summary>
        public string Left()
        {
            if (!directionFacing.HasValue)
            {
                return string.Empty;
            }
            directionFacing = (Direction)(((int)directionFacing + 3) % 4);
            if ((x == 0 && directionFacing == Direction.WEST) || (y == 0 && directionFacing == Direction.SOUTH) || (x == tableSize - 1 && directionFacing == Direction.EAST) || (y == tableSize - 1 && directionFacing == Direction.NORTH))
            {
                return "Robot is at the edge of the table";
            }
            return "Robot turning left!!";
        }

        /// <summary>
        /// Rotates the robot 90 degrees to the right.
        /// </summary>
        public string Right()
        {
            if (!directionFacing.HasValue)
            {
                return string.Empty;
            }
            directionFacing = (Direction)(((int)directionFacing + 1) % 4);

            if ((x == 0 && directionFacing == Direction.WEST) || (y == 0 && directionFacing == Direction.SOUTH) || (x == tableSize - 1 && directionFacing == Direction.EAST) || (y == tableSize - 1 && directionFacing == Direction.NORTH))
            {
                return "Robot is at the edge of the table";
            }
            return "Robot turning right!!";
        }

        /// <summary>
        /// Moves the robot one unit in the direction it is facing.
        /// </summary>
        public string Move()
        {
            if (!x.HasValue || !y.HasValue || !directionFacing.HasValue || tableSize == 0)
            {
                return string.Empty;
            }
            switch (directionFacing)
            {
                case Direction.EAST:
                    if (x < tableSize - 1)
                    {
                        x++;
                    }
                    break;
                case Direction.WEST:
                    if (x > 0)
                    {
                        x--;
                    }
                    break;
                case Direction.NORTH:
                    if (y < tableSize - 1)
                    {
                        y++;
                    }
                    break;

                case Direction.SOUTH:
                    if (y > 0)
                    {
                        y--;
                    }
                    break;
            }
            if ((x == 0 && directionFacing == Direction.WEST) || (y == 0 && directionFacing == Direction.SOUTH) || (x == tableSize - 1 && directionFacing == Direction.EAST) || (y == tableSize - 1 && directionFacing == Direction.NORTH))
            {
                return "Robot is at the edge of the table";
            }
            return "Robot is moving";
        }

        /// <summary>
        /// Places the robot on the table at the specified coordinates and facing direction.
        /// </summary>
        /// <param name="xDistance">The x-coordinate of the robot's position.</param>
        /// <param name="yDistance">The y-coordinate of the robot's position.</param>
        /// <param name="direction">The direction the robot is facing.</param>
        public void Place(int xDistance, int yDistance, Direction direction, int tableSize)
        {
            if (xDistance >= 0 && xDistance < tableSize && yDistance >= 0 && yDistance < tableSize)
            {
                this.tableSize = tableSize;
                x = xDistance;
                y = yDistance;
                directionFacing = direction;
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Reports the current position and facing direction of the robot.
        /// </summary>
        public string Report()
        {
            if (!x.HasValue || !y.HasValue || !directionFacing.HasValue || tableSize == 0)
            {
                return string.Empty;
            }
            return $"{x},{y},{directionFacing}";
        }
    }
}
