using UnityEngine;

public class Tile : MonoBehaviour
{
    public BoardItem item;
    public InputScriptableObject inputData;
    public MeshRenderer renderer;
    private Color color;
    public Color newColor;

    private void Awake()
    {
        color = renderer.material.color;
    }

    public bool HasItem
    {
        get => item != null;
    }

    public Vector3 Position
    {
        get => this.transform.position;
    }

    public void SetItem(BoardItem item)
    {
        this.item = item;
        renderer.material.color = newColor;
    }

    public void OnHoverEnter()
    {
        renderer.material.color = newColor;
    }

    public void OnHoverLeave()
    {
        renderer.material.color = color;
    }

    public void ClearItem()
    {
        this.item = null;
        // renderer.material.color = color;
    }
}
