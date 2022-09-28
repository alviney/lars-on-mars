using UnityEngine;

public enum Direction { Forward, Right, Back, Left };

public class MoveOutput : Output
{
    public Direction direction;

    public MoveOutput(Direction direction)
    {
        this.direction = direction;
    }

    public override Task ToTask(Robot robot)
    {
        Vector3 direction = robot.Forward;

        switch (this.direction)
        {
            case Direction.Forward:
                direction = robot.Forward;
                break;
            case Direction.Right:
                direction = robot.Right;
                break;
            case Direction.Back:
                direction = robot.Back;
                break;
            case Direction.Left:
                direction = robot.Left;
                break;
        }

        return new MoveTask(robot.transform, robot.Position + direction, robot.stats.speed);
    }
}
