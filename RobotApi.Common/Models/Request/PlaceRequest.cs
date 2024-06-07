
namespace RobotApi.Common.Models.Request
{
    /// <summary>
    /// Represents a request to place a robot at a specific position and direction.
    /// </summary>
    public class PlaceRequest
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction DirectionFacing { get; set; }

        public int TableSize { get; set;}
    }
}
