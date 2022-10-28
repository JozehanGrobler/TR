// See https://aka.ms/new-console-template for more information

using TR;
using TR.Models;
using TR.Models.Events;

Console.WriteLine("Starting Robot Simulation...");
Console.WriteLine("Possible Actions");
Console.WriteLine("LEFT");
Console.WriteLine("RIGHT");
Console.WriteLine("MOVE");
Console.WriteLine("PLACE");
var input = Console.ReadLine()?.ToUpper();
var robot = new Robot();
while (input != "EXIT")
{
    switch (input?.ToUpper())
    {
        case "L":
        case "LEFT":
            robot.Dispatch(new RobotEventLeft());
            break;
        case "R":
        case "RIGHT":
            robot.Dispatch(new RobotEventRight());
            break;
        case "M":
        case "MOVE":
            robot.Dispatch(new RobotEventMove());
            break;
        case "P":
        case "PLACE":
            var x = InputManager.GetValidIntInput("Please Provide a value for the Robots X-Coordinate");
            var y = InputManager.GetValidIntInput("Please Provide a value for the Robots Y-Coordinate");
            var direction = InputManager.GetValidEnumInput<Direction>("Please Provide a value for Direction");

            robot.Dispatch(new RobotEventPlace(
                X: x,
                Y: y,
                Direction: direction));
            break;
        case "REPORT":
            robot.Dispatch(new RobotEventReport());
            break;
        case "--HELP":
        case "-H":
        case "HELP":
            Console.WriteLine("Possible Actions");
            Console.WriteLine("LEFT");
            Console.WriteLine("RIGHT");
            Console.WriteLine("MOVE");
            Console.WriteLine("PLACE");
            break;
        default:
            Console.Error.WriteLine($"Unknown Action {input}");
            break;
    }

    input = Console.ReadLine()?.ToUpper();
}