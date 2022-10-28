namespace TR.Models;

using TR.Models.Events;

public record Robot
{
    private readonly int _topLimit = 5;
    private readonly int _bottomLimit = 0;
    private string _state = "INIT";

    public int X { get; private set; }
    public int Y { get; private set; }
    public Direction Direction { get; private set; }

    public void Dispatch(RobotEvent e)
    {
        if (this._state == "INIT" && e is not RobotEventPlace)
        {
            Console.Error.WriteLine("Robot has not been placed");
            return;
        }
        switch (e)
        {
            case RobotEventLeft :
                this.Left();
                break;
            case RobotEventMove :
                this.Move();
                break;
            case RobotEventPlace robotEventPlace:
                this.Place(robotEventPlace);
                break;
            case RobotEventReport :
                this.Report();
                break;
            case RobotEventRight :
                this.Right();
                break;
            default:
                throw new ArgumentOutOfRangeException(e.GetType().ToString());
        }

        this._state = nameof(e);
        Console.Clear();
        // Console.WriteLine($"Event Fired {e.GetType()}");
        this.Report();
    }

    /// <summary>
    /// This function Places the robot on a new location on the board
    /// </summary>
    private void Place(RobotEventPlace place)
    {
        this.X = place.X;
        this.Y = place.Y;
        this.Direction = place.Direction;
    }
    
    /// <summary>
    /// This function moves the Robot 1 step in the direction it is facing.
    /// </summary>
    private void Move()
    {
        switch (this.Direction)
        {
            case Direction.North:
                this.ValidateY(1, () =>
                {
                    this.Y++;
                });
                break;
            case Direction.East:
                this.ValidateX(1, () =>
                {
                    this.X++;
                });
                break;
            case Direction.South:
                this.ValidateY(-1, () =>
                {
                    this.Y--;
                });
                break;
            case Direction.West:
                this.ValidateX(-1, () =>
                {
                    this.X--;
                });
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    /// This function rotates the robot 90 left.
    /// </summary>
    private void Left()
    {
        this.Direction = this.Rotate(-90);
    }

    /// <summary>
    /// This function rotates the robot 90 right.
    /// </summary>
    private void Right()
    {
        this.Direction = this.Rotate(90);
    }
    
    private Direction Rotate(int degrees)
    {
        var facing = (int) this.Direction;
        facing = degrees + facing;
        if (facing < 0)
        {
            facing += 360;
        }
        else  if (facing >= 360)
        {
            facing -= 360;
        }
        return (Direction)facing;
    }
    
    /// <summary>
    /// This function reports the current state of the robot
    /// </summary>
    private void Report()
    {
        Console.WriteLine($"{this.X},{this.Y},{this.Direction.ToString()}");
    }

    /// <summary>
    /// This function validates and allows X-axis movements
    /// </summary>
    private void ValidateX(int x, Action action)
    {
        var result = x + this.X;
        var belowOrAtTopLimit = result <= this._topLimit; 
        var aboveOrAtBottomLimit = result >= this._bottomLimit; 
        if (belowOrAtTopLimit && aboveOrAtBottomLimit)
        {
            action();
        }
    }
    
    /// <summary>
    /// This function validates and allows Y-axis movements
    /// </summary>
    private void ValidateY(int y,Action action)
    {
        var result = y + this.Y;
        var belowOrAtTopLimit = result <= this._topLimit; 
        var aboveOrAtBottomLimit = result >= this._bottomLimit; 
        if (belowOrAtTopLimit && aboveOrAtBottomLimit)
        {
            action();
        }
    }
}