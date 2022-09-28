using UnityEngine;

public class MoveTask : Task
{
    public Transform target;
    public Vector3 origin;
    public Vector3 destination;
    private float speed;

    public MoveTask(Transform target, Vector3 destination, float speed) : base(new MoveTaskValidator())
    {
        this.target = target;
        this.destination = Vector3Int.RoundToInt(destination);
        this.speed = speed;
    }

    public override void Init(Robot robot, Board board)
    {
        Tile destinationTile = board.GetTile(destination);
        destinationTile.item = robot;
    }

    public override void Update()
    {
        if (target.transform.position == destination)
        {
            this.Complete();
        }
        else if (target != null)
        {
            target.LookAt(destination);
            float step = speed * Time.deltaTime;
            target.position = Vector3.MoveTowards(target.position, destination, step);
        }
    }
}
