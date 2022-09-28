using UnityEngine;
using System;

public class OutputUI : MonoBehaviour
{
    public Action<Output> OutputChanged;

    public void OnDirectionChange(Direction direction)
    {
        OutputChanged?.Invoke(new MoveOutput(direction));
    }
}
