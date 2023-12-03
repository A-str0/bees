using System.Collections;
using UnityEngine;

public class Grab : BaseProperty
{
    Rigidbody2D rb; 
    bool isGrabbing = false;
    Vector2 gravityVector = new(0, -9.81f);

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    override public IEnumerator Complete() {
        rb.AddForce(Vector2.up * rb.mass, ForceMode2D.Impulse);
        isGrabbing = true;
        rb.drag = 3f;
        rb.angularDrag = 2f;
        yield return new WaitForSeconds(1f);
        yield return null;
    }
    override public IEnumerator Stop() {
        isGrabbing = false;
        rb.drag = 0f;
        rb.angularDrag = 0.5f;
        yield return null;
    }

    public void FixedUpdate() { 
        switch (isGrabbing) {
            case true:
                rb.AddForce(-gravityVector, ForceMode2D.Force);
                break;
        }
    }
}
