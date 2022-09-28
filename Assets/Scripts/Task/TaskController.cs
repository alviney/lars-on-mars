using UnityEngine;
using System;
using System.Collections.Generic;

// Manages the creation of tasks for all things
public class TaskController : MonoBehaviour
{
    public BoardController boardController;
    private TaskHandler taskHandler;
    private Dictionary<Robot, Task> taskQueue = new Dictionary<Robot, Task>();

    public void AddTask(Task task, Robot robot)
    {
        taskQueue.Add(robot, task);
    }

    public void Update()
    {
        taskHandler?.Update();
    }

    public Dictionary<Robot, Task[][]> GetTasks(int ticks)
    {
        Dictionary<Robot, Task[][]> allPaths = new Dictionary<Robot, Task[][]>();

        foreach (Robot robot in board.Robots)
        {
            Task[][] tasks = new Task[ticks][];
            Vector3 position = robot.Position;
            for (int i = 0; i < ticks; i++)
            {
                position += robot.transform.forward;
                tasks[i] = new Task[1] { new MoveTask(robot.transform, position, robot.stats.speed) };
            }
            allPaths.Add(robot, tasks);
        }

        // For next nTurns 
        // Get "ghost" clones and run each tick as a simulation
        // Return dictionary (key: robot, value: Task[][(nTurns)])

        return allPaths;
    }

    public void SetTasks(Action onCompleteCallback)
    {
        List<Task> tasks = new List<Task>();

        foreach (Tile tile in board.Tiles) tile.ClearItem();
        foreach (Robot robot in board.Robots) board.GetTile(robot.Position).SetItem(robot);
        foreach (Obstacle obstacle in board.Obstacles) board.GetTile(obstacle.Position)?.SetItem(obstacle);

        foreach (KeyValuePair<Robot, Task> entry in taskQueue)
        {
            entry.Value.Init(entry.Key, board);
            tasks.Add(entry.Value);
        }
        taskQueue.Clear();

        foreach (Robot robot in board.Robots)
        {
            Tile currentTile = board.GetTile(robot.Position);
            Task task = GetTaskForRobot(robot, currentTile);
            if (task is MoveTask) task.Init(robot, board);
            tasks.Add(task);
        }

        taskHandler = new TaskHandler(onCompleteCallback, tasks.ToArray());
    }

    public Task GetTaskForRobot(Robot robot, Tile currentTile)
    {
        Tile nextTile = board.GetTile(robot.Position + robot.Forward);
        TaskQueue queue = new TaskQueue();

        ProcessTile(currentTile, robot, queue);
        ProcessTile(nextTile, robot, queue);

        foreach (Vector3 dir in robot.Directions)
        {
            MoveTask moveTask = new MoveTask(robot.transform, robot.Position + dir, robot.stats.speed);
            moveTask.SetStatus(board);
            queue.AddTask(moveTask);
        }

        Task task = new WaitTask();
        foreach (Task _task in queue.tasks)
        {
            if (_task.IsValid)
            {
                task = _task;
                break;
            }
        }

        return task;
    }

    public void ProcessTile(Tile tile, Robot robot, TaskQueue queue)
    {
        Input input = tile?.inputData?.ToInput();
        if (input != null)
        {
            Output output = robot.program.GetOutput(input);
            if (output != null)
            {
                Task task = output.ToTask(robot);
                if (task is MoveTask) task.SetStatus(board);
                queue.AddTask(task);
            }
        }
    }

    private Board board
    {
        get => boardController.board;
    }
}