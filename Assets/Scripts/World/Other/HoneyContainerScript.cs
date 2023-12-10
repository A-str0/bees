using UnityEngine;
using UnityEngine.Events;

public class HoneyContainerScript : MonoBehaviour
{
    [SerializeField] Animator animator;

    public UnityEvent onFilled;
    public UnityEvent onEmpty;

    private void Start() {
        animator = transform.GetComponent<Animator>();
    }

    public void Fill() {
        animator.SetBool("IsFilled", true);
        onFilled?.Invoke();
    }

    public void Empty() {
        animator.SetBool("IsFilled", false);
        onEmpty?.Invoke();
    }
}
