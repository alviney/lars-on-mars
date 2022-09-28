using UnityEngine;
using UnityEngine.InputSystem;

public class BoardUI : MonoBehaviour
{
    public RobotControlsUI robotControls;
    public BoardWorldUI boardWorldUI;
    public GameObject boardGameplayUI;
    public RobotManager robotManager;
    public TileManager tileManager;

    private LevelManager levelManager;
    public GameObject robotPrefab;
    private Vector2 mousePosition;

    private Tile target;

    private void Awake()
    {
        levelManager = GetComponentInParent<LevelManager>();
    }

    private void OnEnable()
    {
        levelManager.onStateChanged += OnStateChanged;
    }

    private void OnDisable()
    {
        levelManager.onStateChanged -= OnStateChanged;
    }

    private void OnStateChanged(LevelEvent boardEvent)
    {
        switch (boardEvent)
        {
            case LevelEvent.Play:
                OnPlay();
                break;
            case LevelEvent.Pause:
                OnPause();
                break;
            case LevelEvent.Resume:
                OnResume();
                break;
        }
    }

    public void OnPlay()
    {
        robotControls.gameObject.SetActive(false);
        boardWorldUI.gameObject.SetActive(false);
        boardGameplayUI.SetActive(true);
    }

    public void OnPause()
    {
        robotControls.gameObject.SetActive(true);
        boardWorldUI.gameObject.SetActive(true);
    }

    public void OnResume()
    {
        robotControls.gameObject.SetActive(false);
        boardWorldUI.gameObject.SetActive(false);
    }

    public void OnPoint(InputAction.CallbackContext ctx)
    {
        Vector2 point = ctx.ReadValue<Vector2>();
        if (point != null) mousePosition = point;
        Raycast();
    }

    private void Raycast()
    {
        target?.OnHoverLeave();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Vector3Int point = Vector3Int.RoundToInt(hit.point);
            target = tileManager.GetTile(point + Vector3.up);
            target?.OnHoverEnter();
        }

    }

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3Int point = Vector3Int.RoundToInt(hit.point);

                Robot robot = robotManager.GetRobotAtPosition(point);
                if (robot)
                {
                    Debug.Log("robot already at positon");
                }
                else
                {
                    GameObject instance = Instantiate(robotPrefab, point + Vector3Int.up, Quaternion.identity, robotManager.transform);
                    robot = instance.GetComponent<Robot>();
                    Debug.Log("robot created");
                }

                Select(robot);
            }

        }
    }

    private void Select(Robot robot)
    {
        if (robot)
        {
            robotControls.gameObject.SetActive(true);
            robotControls.Init(robot);
            robotManager.Refresh();

            boardWorldUI.SetSelection(robot.transform.position);
        }
    }
}
