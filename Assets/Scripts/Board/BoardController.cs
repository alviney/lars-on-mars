using UnityEngine;

public class BoardController : MonoBehaviour
{
    public RobotManager robotManager;
    public TileManager tileManager;
    public ObstacleManager obstacleManager;

    public Board board;

    private void Awake()
    {
        board = new Board(this);
    }
}