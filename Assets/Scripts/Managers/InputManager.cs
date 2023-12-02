using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance { get; private set; }

    public Movement_2D playerMovement;

    public PlayerControls controls;
    public PlayerControls.PlayerActions playerActions;

    float input;

    private void Awake() {
        if (Instance == null) Instance = this;
        else Debug.LogWarning("InputManager is already instanced");

        controls = new PlayerControls();
        playerActions = controls.Player;

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
