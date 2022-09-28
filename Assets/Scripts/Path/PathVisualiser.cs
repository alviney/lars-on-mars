using UnityEngine;

public class PathVisualiser : MonoBehaviour
{
    public GameObject moveSpritePrefab;

    public void Update(Task[][] path)
    {
        foreach (Transform child in this.transform) Destroy(child.gameObject);

        foreach (Task[] tasks in path)
        {
            foreach (Task task in tasks)
            {
                if (task is MoveTask)
                {
                    Instantiate(moveSpritePrefab, ((MoveTask)task).destination, Quaternion.identity, this.transform);
                }
            }
        }
    }
}
