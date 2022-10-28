# Toy Robot Code Challenge

## This is Console Application that manages the position of a toy robot on a small 5 x 5 unit table.

### To run the application

#### In the source Directory

`dotnet ./Core/bin/Debug/net6.0/Core.dll`
or run
`dotnet run --project ./Core/Core.csproj`

### To run the Unit tests run

#### In the source Directory

`dotnet test ./UnitTests`

##### How to use the console app

The console App runs with the following commands:
(The app is case insensitive)

- `PLACE/P` with follow up prompts for the co-ordinates and the direction
- `MOVE/M` to move one unit in the robot facing direction
- `LEFT/L` to rotate 90 degrees to the left
- `RIGHT/R` to rotate 90 degrees to the right
- `REPORT` to print out the Robots current state
- `HELP/H` to show the possible commands you can give to the robot
- `EXIT` to exit the application

##### Design Decisions

The Robot is a small state machine
The state machine reacts to certain events
The events determine what the resulting state of the Robot is
