using System;

public class Task
{
    public Action onComplete;
    public bool isComplete;
    public TaskStatus status;
    public TaskValidator validator;

    public Task(TaskValidator validator)
    {
        this.validator = validator;
    }

    public virtual void Init(Robot robot, Board board) { }

    public virtual void Update() { }

    public virtual void Complete()
    {
        this.isComplete = true;
        this.onComplete?.Invoke();
    }

    public void SetStatus(Board board)
    {
        status = validator.Status(this, board);
        if (status == TaskStatus.Hold) Complete();
    }

    public virtual bool IsValid
    {
        get => status != TaskStatus.Invalid;
    }

    public virtual bool IsHold
    {
        get => status == TaskStatus.Hold;
    }
}