using System.Collections.Generic;
using UnityEngine;

public class PathsController : MonoBehaviour
{
    public Dictionary<Robot, PathVisualiser> paths = new Dictionary<Robot, PathVisualiser>();
    public GameObject pathVisualiserPrefab;

    public void Update(Dictionary<Robot, Task[][]> tasksForTicks)
    {
        foreach (KeyValuePair<Robot, Task[][]> entry in tasksForTicks)
        {
            Robot robot = entry.Key;
            Task[][] path = entry.Value;

            if (!this.paths.ContainsKey(robot))
            {
                GameObject instance = Instantiate(pathVisualiserPrefab);
                this.paths.Add(robot, instance.GetComponent<PathVisualiser>());
            }

            this.paths[robot]?.Update(path);
        }
    }
}
