using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class RobotManager : MonoBehaviour
{
    public List<Robot> robots { get; private set; } = new List<Robot>();

    public void Refresh()
    {
        this.robots = GetComponentsInChildren<Robot>().Where((r) => r.enabled).ToList();
    }

    public Robot GetRobotAtPosition(Vector3 position)
    {
        Vector3Int roundedPos = Vector3Int.RoundToInt(position);
        Vector3Int pos = new Vector3Int(roundedPos.x, 1, roundedPos.z);
        return this.robots.Find((r) => Vector3Int.RoundToInt(r.transform.position) == pos);
    }

    public Robot[] Robots
    {
        get => robots.OrderByDescending((r) => r.stats.priority).ToArray();
    }
}