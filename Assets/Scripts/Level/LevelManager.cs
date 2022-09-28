using System;
using UnityEngine;

public enum LevelEvent { Setup, Play, Pause, Resume }

public class LevelManager : MonoBehaviour
{
    // Actions
    public Action<LevelEvent> onStateChanged;

    // References
    public TaskController taskController;
    public PathsController pathsController;

    // Variables
    public int tickLength = 1;
    private int tick = 0;
    private bool paused = false;
    private bool tickInProgress = false;

    public void Play()
    {
        NextTick();
        onStateChanged?.Invoke(LevelEvent.Play);
    }

    public void Pause()
    {
        paused = true;
        onStateChanged?.Invoke(LevelEvent.Pause);
    }

    public void Resume()
    {
        paused = false;
        onStateChanged?.Invoke(LevelEvent.Resume);
        NextTick();
    }

    public void RecalculatePaths()
    {
        pathsController.Update(taskController.GetTasks(tickLength));
    }

    private void NextTick()
    {
        if (tickInProgress) return;

        tickInProgress = true;
        taskController.SetTasks(OnTickComplete);
        tick++;
    }

    private void OnTickComplete()
    {
        tickInProgress = false;

        if ((tick % tickLength == 0)) Pause();
        else if (!paused) NextTick();
    }
}
