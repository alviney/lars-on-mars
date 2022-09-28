using UnityEngine;
using UnityEngine.UI;
using TMPro;


[RequireComponent(typeof(Button))]
public class InputElementUI : MonoBehaviour
{
    public InputScriptableObject inputData;
    public bool setOnAwake;
    private InputUI inputUI;
    private Button button;
    private Image image;


    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        button.onClick.AddListener(HandleClick);
        inputUI = GetComponentInParent<InputUI>();

        GetComponentInChildren<TextMeshProUGUI>().text = inputData?.name ?? "Input";
    }

    private void Start()
    {
        if (setOnAwake) inputUI.SetInput(inputData);
    }

    private void OnEnable()
    {
        if (inputUI != null) inputUI.InputChanged.AddListener(HandleInputChange);
    }

    private void OnDisable()
    {
        if (inputUI != null) inputUI.InputChanged.RemoveListener(HandleInputChange);
    }

    public void HandleInputChange(Input input)
    {
        bool isActive = input.name == (inputData?.name ?? "");
        SetActive(isActive);
    }

    private void SetActive(bool isActive)
    {
        image.color = isActive ? Color.red : Color.white;
    }

    private void HandleClick()
    {
        inputUI.SetInput(inputData);
    }
}
