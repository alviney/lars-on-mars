using UnityEngine;
using System;
using System.Linq;

// Manages the lifecylce of tasks
public class TaskHandler
{
    public Action onCompleteCallback;
    public Task[] tasks;

    public TaskHandler(Action onCompleteCallback, Task[] tasks)
    {
        this.onCompleteCallback = onCompleteCallback;
        this.tasks = tasks;

        foreach (Task task in tasks) task.onComplete += HandleTaskComplete;
    }

    public void Update()
    {
        foreach (Task task in tasks)
        {
            if (!task.isComplete) task.Update();
        };
    }

    public void HandleTaskComplete()
    {
        if (tasks.All((t) => t.isComplete)) this.onCompleteCallback();
    }
}
