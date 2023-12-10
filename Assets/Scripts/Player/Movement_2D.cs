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

    [SerializeField] CameraController camController;
    [SerializeField] Collider2D groundCheck;
    [SerializeField] Collider2D wallCheck;
    [SerializeField] GameObject GUI;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] LineRenderer lineRenderer;


    Rigidbody2D rb;
    float input;
    GameObject ground;
    bool isAiming;
    Vector2 aimDir;

    public bool IsMoving() => input != 0f;
    public bool IsFalling() => rb.velocity.y != 0f;
    public bool IsSliding() => IsWalled();
    public bool IsAiming() => isAiming;
    public bool isJumping;
    public Vector2 GetVelocity() => rb.velocity;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    float horVelocity;
    private void Update() {
        SwitchState();

        switch (playerState) {
            case PlayerState.Default:
                lineRenderer.enabled = false;
                horVelocity = Mathf.Lerp(rb.velocity.x, input * speed, Time.deltaTime * smoothness);
                break;
            case PlayerState.Aiming:
                //lineRenderer.enabled = true;
                lineRenderer.SetPosition(0, transform.position);
                lineRenderer.SetPosition(1, Physics2D.Raycast(transform.position, aimDir.normalized, Mathf.Infinity, shootLayerMask).point);
                break;
            case PlayerState.InAir:
                lineRenderer.enabled = false;
                if (input != 0) horVelocity = Mathf.Lerp(rb.velocity.x, input * speed, Time.deltaTime * smoothness / 7f);
                break;
        }

        rb.velocity = new Vector2(horVelocity, rb.velocity.y);
    }

    int shootLayerMask = ~(1 << 3 | 1 << 7);
    public void Jump() { 
        if (IsGrounded()) StartCoroutine(OnJump()); 
        else if (IsWalled()) StartCoroutine(OnWallJump()); 
    }
    public void Shoot() {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, aimDir.normalized, Mathf.Infinity, shootLayerMask);
        if (hit.collider) {
            if (hit.collider.gameObject.TryGetComponent<BaseChangable>(out BaseChangable script)) {
                camController.Concentrate(hit.collider.transform);
                script.UseUI();
                //GUI.gameObject.SetActive(false);
            }
        }
    }
    public void UnuseUI() {
        camController.Unconcentrate();
    }

    public void StartDialogue(string[] text) => StartCoroutine(StartDialogueCoroutine(text));
    public IEnumerator StartDialogueCoroutine(string[] text) {
        dialogueBox.transform.position = transform.position;
        dialogueBox.SetActive(true);
        dialogueBox.GetComponent<DialogueScript>().SetText(text);
        yield return dialogueBox.GetComponent<DialogueScript>().SetTextCoroutine(text);
    }

    public void StartDialogue(string text) => StartCoroutine(StartDialogueCoroutine(text));

    public IEnumerator StartDialogueCoroutine(string text) {
        dialogueBox.transform.position = transform.position;
        dialogueBox.SetActive(true);
        dialogueBox.GetComponent<DialogueScript>().SetText(text);
        yield return dialogueBox.GetComponent<DialogueScript>().SetTextCoroutine(text);
    }

    private IEnumerator OnJump() {
        isJumping = true;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(jumpForce * 0.1f);
        isJumping = false;
        yield return null;
    }
    private IEnumerator OnWallJump() {
        isJumping = true;
        float jumpDir = transform.localScale.x * -input;
        Vector2 target = new Vector2(jumpDir, 1.1f) * jumpForce * Mathf.Abs(input);
        rb.velocity = target;
        yield return new WaitForSeconds(jumpForce * 0.1f);
        isJumping = false;
        yield return null;
    }
    public void GetOff() { if (ground && IsGrounded()) StartCoroutine(GetOffPlatform()); }

    private IEnumerator GetOffPlatform() {
        PlatformEffector2D pe = ground.GetComponent<PlatformEffector2D>();
        pe.rotationalOffset = 180;
        yield return new WaitForSeconds(0.5f);
        pe.rotationalOffset = 0;
        yield return null;
    }

    public void ReceiveInput(float _input, bool _isAiming, Vector2 _aimDir) {
        input = _input;
        isAiming = _isAiming;
        aimDir = _aimDir;
    }

    private IEnumerator DisableCollision() {
        BoxCollider2D platformCollider = ground.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), platformCollider, false);
    }

    int layer = ~(1 << 3);
    private bool IsGrounded() {
        RaycastHit2D hit = Physics2D.BoxCast(groundCheck.bounds.center, groundCheck.bounds.size, 0f, Vector2.down, 0.1f, layer);
        if (hit) ground = hit.collider.gameObject.CompareTag("Platform") ? hit.collider.gameObject : null;
        return hit.point != Vector2.zero && rb.velocity.y == 0;
    }
    private bool IsWalled() {
        RaycastHit2D hit = Physics2D.BoxCast(groundCheck.bounds.center, wallCheck.bounds.size, 0f, Vector2.down, 0.1f, layer);
        return hit.point != Vector2.zero;
    }

    private void SwitchState() {
        if (IsGrounded()) {
            if (isAiming) playerState = PlayerState.Aiming;
            else playerState = PlayerState.Default;
        } else {
            playerState = PlayerState.InAir;
        }
    }
}

public enum PlayerState
{
    Default,
    InAir,
    Aiming
}