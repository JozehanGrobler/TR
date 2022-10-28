namespace UnitTests;

using Xunit;
using TR.Models;
using TR.Models.Events;

public class RobotOutputUnitTests
{
    [Fact]
    public void TestA()
    {
        var robot  = new Robot();
        robot.Dispatch(new RobotEventPlace(X: 0, Y: 0, Direction.North));
        robot.Dispatch(new RobotEventMove());
        robot.Dispatch(new RobotEventReport());
        Assert.Equal(0, robot.X);
        Assert.Equal(1, robot.Y);
        Assert.Equal(Direction.North, robot.Direction);
    }
    
    [Fact]
    public void TestB()
    {
        var robot  = new Robot();
        robot.Dispatch(new RobotEventPlace(X: 0, Y: 0, Direction.North));
        robot.Dispatch(new RobotEventLeft());
        robot.Dispatch(new RobotEventReport());
        Assert.Equal(0, robot.X);
        Assert.Equal(0, robot.Y);
        Assert.Equal(Direction.West, robot.Direction);
    }
    
    [Fact]
    public void TestC()
    {
        var robot  = new Robot();
        robot.Dispatch(new RobotEventPlace(X: 1, Y: 2, Direction.East));
        robot.Dispatch(new RobotEventMove());
        robot.Dispatch(new RobotEventMove());
        robot.Dispatch(new RobotEventLeft());
        robot.Dispatch(new RobotEventMove());
        robot.Dispatch(new RobotEventReport());
        Assert.Equal(3, robot.X);
        Assert.Equal(3, robot.Y);
        Assert.Equal(Direction.North, robot.Direction);
    }
    
    [Fact]
    public void TestD()
    {
        var robot  = new Robot();
        robot.Dispatch(new RobotEventPlace(X: 0, Y: 0, Direction.North));
        for (int j = 0; j < 4; j++)
        {
            for (int i = 0; i < 10; i++)
            {
                robot.Dispatch(new RobotEventMove());
            }
            robot.Dispatch(new RobotEventRight());
        }
        Assert.Equal(0, robot.X);
        Assert.Equal(0, robot.Y);
        Assert.Equal(Direction.North, robot.Direction);
    }
}