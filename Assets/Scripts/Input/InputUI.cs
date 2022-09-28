using UnityEngine;
using UnityEngine.Events;

public class InputUI : MonoBehaviour
{
    public Input input;
    public UnityEvent<Input> InputChanged;

    public void SetInput(InputScriptableObject inputData)
    {
        this.input = inputData.ToInput();
        this.InputChanged?.Invoke(input);
    }
}
