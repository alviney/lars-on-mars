using UnityEngine;
using System.Linq;

public class Board
{
    public BoardController controller;

    public Board(BoardController controller)
    {
        this.controller = controller;
    }

    public Tile GetTile(Vector3 position)
    {
        return this.controller.tileManager.GetTile(position);
    }

    public Tile[] Tiles
    {
        get => this.controller.tileManager.tiles.Values.ToArray();
    }

    public Obstacle[] Obstacles
    {
        get => this.controller.obstacleManager.Obstacles;
    }

    public Robot[] Robots
    {
        get => this.controller.robotManager.Robots;
    }
}
