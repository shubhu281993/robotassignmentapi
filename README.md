# Robot Game API project

This API project is built on .NET Core 8.0 and is designed to be consumed by a React JS-based UI.

## Installation

To install the project, follow these instructions:

git clone https://github.com/shubhu281993/robotassignmentapi.git

## Playground

Explore the APIs by visiting the Swagger documentation at the following URL:
http://robotapp.southindia.cloudapp.azure.com/api/swagger/index.html

## How to run

The API provides 5 endpoints to support the Move, Left, Right, Place, and Report functionalities for the Robot Toy game:

1) The Place endpoint accepts input for the x-coordinate, y-coordinate, direction the robot is facing, and the table size. It then places the robot at the specified coordinates.

2) The Left endpoint changes the robot's facing direction to the left. For example, if the robot is facing North, after calling the Left endpoint, the robot will face West.

3) The Right endpoint changes the robot's facing direction to the right. For example, if the robot is facing North, after calling the Right endpoint, the robot will face East.

4) The Move endpoint moves the robot one unit forward in its current facing direction.

5) The Report endpoint provides information about the robot's current position.

Enjoy interacting with the Robot Game API!
