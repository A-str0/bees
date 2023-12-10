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
        animator.SetBool("IsInAir", controller.IsFalling());
        animator.SetBool("Jump", controller.isJumping);
        animator.SetBool("IsSliding", controller.IsSliding());
        animator.SetBool("IsAiming", controller.IsAiming());
        if (controller.GetVelocity().x > 0) {
            spriteRenderer.flipX = false;
        } else if (controller.GetVelocity().x < 0) {
            spriteRenderer.flipX= true;
        }
    }
}
