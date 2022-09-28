using UnityEngine;
using UnityEngine.InputSystem;

public class RobotControlsUI : MonoBehaviour
{
    public InputsManagerScriptableObject inputsDataManager;
    public InputUI inputUI;
    public OutputUI outputUI;
    public Input input;
    public Output output;
    private Robot robot;

    private void OnEnable()
    {
        if (inputUI != null) inputUI.InputChanged.AddListener(OnInputChanged);
        if (outputUI != null) outputUI.OutputChanged += OnOutputChanged;
    }

    private void OnDisable()
    {
        if (inputUI != null) inputUI.InputChanged.RemoveListener(OnInputChanged);
        if (outputUI != null) outputUI.OutputChanged -= OnOutputChanged;
    }

    public void Init(Robot robot)
    {
        this.robot = robot;
    }

    public void HandleAction(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            TaskController taskController = GetComponentInParent<TaskController>();
            if (taskController != null)
            {
                taskController.AddTask(new FireTask(), robot);
            }
        }
    }

    private void OnInputChanged(Input input)
    {
        this.input = input;
    }

    private void OnOutputChanged(Output output)
    {
        this.output = output;
        robot.program.Add(input.name, output);
        if (input.name == inputsDataManager.start.name && this.output is MoveOutput)
        {
            HandleStartingPosition(((MoveOutput)this.output).direction);
        }
    }

    private void HandleStartingPosition(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
                robot.transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
            case Direction.Right:
                robot.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case Direction.Back:
                robot.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case Direction.Left:
                robot.transform.rotation = Quaternion.Euler(0, -90, 0);
                break;
        }
    }
}
