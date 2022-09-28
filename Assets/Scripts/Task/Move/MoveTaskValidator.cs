using UnityEngine;

public class MoveTaskValidator : TaskValidator
{
    public override TaskStatus Status(Task task, Board board)
    {
        MoveTask moveTask = (MoveTask)task;

        Tile destinationTile = board.GetTile(moveTask.destination);
        if (destinationTile == null) return TaskStatus.Invalid;
        else if (destinationTile.item == null) return TaskStatus.Valid;
        else return TaskStatus.Hold;
    }
}
