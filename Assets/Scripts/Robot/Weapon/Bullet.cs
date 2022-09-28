using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;

    private void Update()
    {
        transform.position += direction * Time.deltaTime * 4;
    }
}
