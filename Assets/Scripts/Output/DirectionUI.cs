using UnityEngine;
using UnityEngine.Events;

public class DirectionUI : MonoBehaviour
{
    public UnityEvent<Direction> DirectionChanged;

    public void OnDirectionChange(string dir)
    {
        Direction direction = Direction.Forward;
        switch (dir)
        {
            case "up":
                direction = Direction.Forward;
                break;
            case "right":
                direction = Direction.Right;
                break;
            case "down":
                direction = Direction.Back;
                break;
            case "left":
                direction = Direction.Left;
                break;
        }

        DirectionChanged?.Invoke(direction);
    }
}
