using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform barrel;

    public void Fire()
    {
        GameObject instance = Instantiate(bulletPrefab, barrel.position, Quaternion.identity);
        instance.GetComponent<Bullet>().direction = barrel.forward;
        Destroy(instance, 5);
    }
}
