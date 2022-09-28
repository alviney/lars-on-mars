using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ObstacleManager : MonoBehaviour
{
    public List<Obstacle> obstacles { get; private set; } = new List<Obstacle>();

    private void Awake() {
        Refresh();
    }

    public void Refresh()
    {
        this.obstacles = GetComponentsInChildren<Obstacle>().Where((r) => r.enabled).ToList();
    }

    public Obstacle[] Obstacles {
        get => this.obstacles.ToArray();
    }
}
