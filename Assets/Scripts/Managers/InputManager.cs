using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Movement_2D playerMovement;

    public PlayerControls controls;
    public PlayerControls.PlayerActions playerActions;

    public event System.Action<Vector2> onClick;

    InputAction pos;
    float input;

    public Vector2 GetPointerPos() => Camera.main.ScreenToWorldPoint(pos.ReadValue<Vector2>());

    private void Awake() {
        if (Instance == null) Instance = this;
        else Debug.LogWarning("InputManager is already instanced");

        controls = new PlayerControls();
        playerActions = controls.Player;
        controls.Enable();
        pos = controls.FindAction("Position");
    }

    private void Start() {
        playerActions.Click.performed += ctx => onClick?.Invoke(GetPointerPos());
        playerActions.Move.performed += ctx => input = ctx.ReadValue<float>();
        playerActions.Jump.performed += ctx => playerMovement.Jump();
    }

    private void Update() {
        playerMovement.ReceiveInput(input);
    }

    private void OnEnable() {
        controls.Enable();
    }
    private void OnDestroy() {
        controls.Disable();
    }
}
