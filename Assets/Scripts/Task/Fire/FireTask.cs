public class FireTask : Task
{
    public FireTask() : base(new MoveTaskValidator()) { }

    public override void Init(Robot robot, Board board)
    {
        robot.Fire();
        this.Complete();
    }
}
