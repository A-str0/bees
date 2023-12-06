using UnityEngine;
using System.Collections;

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
    GameObject ground;

    public bool IsMoving() => input != 0f;
    public bool IsFalling() => rb.velocity.y != 0f;
    public Vector2 GetVelocity() => rb.velocity;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    float horVelocity;
    private void Update() {
        SwitchState();

        switch (playerState) {
            case PlayerState.Default:
                horVelocity = Mathf.Lerp(rb.velocity.x, input * speed, Time.deltaTime * smoothness);
                break;
            case PlayerState.Aiming:

                break;
            case PlayerState.InAir:
                if (input != 0) horVelocity = Mathf.Lerp(rb.velocity.x, input * speed, Time.deltaTime * smoothness / 7f);
                break;
            case PlayerState.Damage:
                Debug.Log("Damage taken");
                break;
        }

        rb.velocity = new Vector2(horVelocity, rb.velocity.y);
        //if (ground) rb.velocity = new Vector2(rb.velocity.x + ground.GetComponent<Rigidbody2D>().velocity.x, 
           // rb.velocity.y + Mathf.Clamp(ground.GetComponent<Rigidbody2D>().velocity.y, float.MinValue, 0));
    }

    public void Jump() { if (IsGrounded()) rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); }
    public void GetOff() { if (ground && IsGrounded()) StartCoroutine(GetOffPlatform()); }

    private IEnumerator GetOffPlatform() {
        PlatformEffector2D pe = ground.GetComponent<PlatformEffector2D>();
        pe.rotationalOffset = 180;
        yield return new WaitForSeconds(0.5f);
        pe.rotationalOffset = 0;
        yield return null;
    }

    public void ReceiveInput(float _input) {
        input = _input;
    }

    private IEnumerator DisableCollision() {
        BoxCollider2D platformCollider = ground.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platformCollider, false);
    }

    int layerMask = 1 << 6;
    private bool IsGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(groundCheck.bounds.center, groundCheck.bounds.size, 0f, Vector2.down, 0.1f, layerMask);
        if (hit) ground = hit.collider.gameObject.CompareTag("Platform") ? hit.collider.gameObject : null;
        return hit.point != Vector2.zero && rb.velocity.y == 0;
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