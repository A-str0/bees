using System.Collections;
using UnityEngine;

public class ZeroGravity : BaseProperty
{
    Rigidbody2D rb; 
    bool isFlying = false;
    Vector2 gravityVector = new(0, -9.81f);

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    override public IEnumerator Complete() {
        rb.AddForce(Vector2.up * Mathf.Pow(rb.mass, 1f), ForceMode2D.Impulse);
        isFlying = true;
        rb.drag = 2f;
        rb.angularDrag = 1f;
        yield return new WaitForSeconds(1f);
        yield return null;
    }
    override public IEnumerator Stop() {
        isFlying = false;
        rb.drag = 0f;
        rb.angularDrag = 0.5f;
        yield return null;
    }

    public void FixedUpdate() { 
        switch (isFlying) {
            case true:
                rb.AddForce(-gravityVector * rb.mass, ForceMode2D.Force);
                break;
        }
    }
}
