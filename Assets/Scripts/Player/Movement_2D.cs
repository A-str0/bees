using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Movement_2D : MonoBehaviour
{
    [SerializeField] PlayerState playerState;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float smoothness = 13f;

    [SerializeField] Collider2D groundCheck;

    Rigidbody2D rb;
    float input;

    public bool IsMoving() => input != 0f;
    public bool IsFalling() => rb.velocity.y != 0f;
    public Vector2 GetVelocity() => rb.velocity;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    float horVelocity;
    float targetHorVelocity;
    private void Update() {
        SwitchState();

        switch (playerState) {
            case PlayerState.Default:
                targetHorVelocity = input * speed;
                break;
            case PlayerState.Aiming:

                break;
            case PlayerState.InAir:
                break;
            case PlayerState.Damage:
                Debug.Log("Damage taken");
                break;
        }

        horVelocity = Mathf.Lerp(horVelocity, targetHorVelocity, Time.deltaTime * smoothness);
        rb.velocity = new Vector2(horVelocity, rb.velocity.y);
    }

    public void Jump() { if (IsGrounded()) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); }
    public void Shoot() { 

    }

    public void ReceiveInput(float _input) {
        input = _input;
    }

    int layerMask = 1 << 6;
    private bool IsGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(groundCheck.bounds.center, groundCheck.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        return hit.point != Vector2.zero;
    }

    private void SwitchState() {
        if (IsGrounded()) {
            playerState = PlayerState.Default;
        } else {
            playerState = PlayerState.InAir;
        }
    }
}

public enum PlayerState
{
    Default,
    InAir,
    Aiming,
    Damage
}