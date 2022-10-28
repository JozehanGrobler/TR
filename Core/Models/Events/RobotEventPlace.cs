namespace TR.Models.Events;

public record RobotEventPlace(int X, int Y, Direction Direction): RobotEvent(nameof(RobotEventPlace));