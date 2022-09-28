using System.Collections.Generic;

public class TaskQueue
{
    public List<Task> tasks = new List<Task>();

    public void AddTask(Task task)
    {
        this.tasks.Add(task);
    }
}
