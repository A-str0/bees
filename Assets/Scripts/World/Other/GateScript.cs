using System.Collections;
using UnityEngine;

public class GateScript : MonoBehaviour
{
    public GameObject door;
    Animator animator;

    private void Start() {
        animator = transform.GetComponent<Animator>();
    }

    public void Open() => StartCoroutine(Opening());
    public void Close() => StartCoroutine(Closing());

    private IEnumerator Opening() {
        animator.SetBool("IsOpened", true);
        yield return null;
    }

    private IEnumerator Closing() {
        animator.SetBool("IsOpened", false);
        yield return null;
    }
}
