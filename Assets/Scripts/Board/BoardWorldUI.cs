using UnityEngine;

public class BoardWorldUI : MonoBehaviour
{
    public Transform selection;

    public void SetSelection(Vector3 position)
    {
        selection.gameObject.SetActive(true);
        selection.position = position;
    }
}
