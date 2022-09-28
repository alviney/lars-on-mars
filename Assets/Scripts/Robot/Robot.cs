
using UnityEngine;

public class Robot : MonoBehaviour, BoardItem
{
    public Weapon weapon;
    public RobotStats stats;
    public Program program;
    public int priority = 0;

    private void Awake()
    {
        stats = new RobotStats();
        stats.priority = priority;
        program = new Program();
    }

    public void Fire()
    {
        weapon.Fire();
    }

    public Vector3 Position
    {
        get => this.transform.position;
    }

    public Vector3 Forward
    {
        get => this.transform.forward;
    }

    public Vector3 Back
    {
        get => -this.transform.forward;
    }

    public Vector3 Right
    {
        get => this.transform.right;
    }

    public Vector3 Left
    {
        get => -this.transform.right;
    }

    public Vector3[] Directions
    {
        get => new Vector3[4] { Forward, Right, Left, Back };
    }
}