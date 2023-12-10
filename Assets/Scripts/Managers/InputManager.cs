using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Movement_2D playerMovement;

    public PlayerControls controls;
    public PlayerControls.PlayerActions playerActions;

    public event System.Action<Vector2> onClick;

    InputAction pos;
    float input;
    bool isAiming = false;
    Vector2 aimDir;

    public Vector2 GetPointerPos() => Camera.main.ScreenToWorldPoint(pos.ReadValue<Vector2>());

    private void Awake() {
        if (Instance == null) Instance = this;
        else Debug.LogWarning("InputManager is already instanced");

        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement_2D>();
        controls = new PlayerControls();
        playerActions = controls.Player;
        controls.Enable();
        pos = controls.FindAction("Position");
    }

    private void Start() {
        playerActions.Click.performed += ctx => onClick?.Invoke(GetPointerPos());
        playerActions.Move.performed += ctx => input = ctx.ReadValue<float>();
        playerActions.Jump.performed += ctx => playerMovement.Jump();
        playerActions.GetOff.performed += ctx => playerMovement.GetOff();
        playerActions.Aim.performed += ctx => { 
            aimDir = ctx.ReadValue<Vector2>(); 
            isAiming = aimDir != Vector2.zero;
        };
        playerActions.Aim.canceled += ctx => playerMovement.Shoot();
    }

    private void Update() {
        playerMovement.ReceiveInput(input, isAiming, aimDir);
    }

    private void OnEnable() {
        controls.Enable();
    }
    private void OnDestroy() {
        controls.Disable();
    }
}
