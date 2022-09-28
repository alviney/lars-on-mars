using UnityEngine;
using System.Collections.Generic;

public class TileManager : MonoBehaviour
{
    public Dictionary<string, Tile> tiles = new Dictionary<string, Tile>();

    private void Awake()
    {
        Tile[] tiles = GetComponentsInChildren<Tile>();
        foreach (Tile tile in tiles)
        {
            this.tiles.Add(Utils.GetHashCode(tile.transform.position), tile);
        }
    }

    public Tile GetTile(Vector3 position)
    {
        Tile tile;
        if (this.tiles.TryGetValue(Utils.GetHashCode(position), out tile)) return tile;
        return null;
    }
}