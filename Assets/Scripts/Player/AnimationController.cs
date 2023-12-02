using UnityEngine;

public class AnimationController : MonoBehaviour
{
    Movement_2D controller;
    Animator animator;
    [SerializeField] SpriteRenderer spriteRenderer;

    private void Start() {
        controller = GetComponent<Movement_2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool("IsMoving", controller.IsMoving());
        if (controller.GetVelocity().x > 0) {
            spriteRenderer.flipX = false;
        } else if (controller.GetVelocity().x < 0) {
            spriteRenderer.flipX= true;
        }
    }
}
