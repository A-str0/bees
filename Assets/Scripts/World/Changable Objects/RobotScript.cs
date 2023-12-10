using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RobotScript : BaseChangable
{
    public float radius = 2f;

    private bool isInAir = false;

    override public void OnStart() {
        if (isFinished) StartCoroutine(ExecuteSequence());
    }

    private void Update() {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.up);
        foreach (var h in hits) {
            if (h.collider.gameObject.TryGetComponent<IInteractable>(out IInteractable obj)) {
                if (isInAir) obj.Activate();
            }
        }
    }

    public void OnCollisionEnter2D() {
        isInAir = false;
    }

    public void OnCollisionExit2D() {
        isInAir = true;
    }
}
