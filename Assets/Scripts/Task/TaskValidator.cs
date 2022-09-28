public enum TaskStatus { Valid, Invalid, Hold }

public class TaskValidator
{
    public virtual TaskStatus Status(Task task, Board board)
    {
        return TaskStatus.Valid;
    }
}
