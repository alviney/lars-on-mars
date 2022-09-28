using UnityEngine;
using TMPro;

public class InputLabelUI : MonoBehaviour
{
    private TextMeshProUGUI label;

    private void Awake()
    {
        label = GetComponent<TextMeshProUGUI>();
    }

    public void SetLabel(Input input)
    {
        label.text = input?.name;
    }
}
