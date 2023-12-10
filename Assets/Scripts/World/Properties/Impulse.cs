using System.Collections;
using UnityEngine;

public class Impulse : BaseProperty
{
    Rigidbody2D rb; 
    public Vector2 direction = new(1f, 0f);
    public float strength = 5f;

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        if (!isStarted) return;
        rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, Time.deltaTime);
        if (rb.velocity.x <= 0.05f && rb.velocity.y <= 0.05f) isStarted = false;
    }

    bool isStarted = false;
    override public IEnumerator Complete() {
        switch (rb.bodyType) {
            case RigidbodyType2D.Dynamic:
                rb.AddForce(direction.normalized * 3f * strength * rb.mass, ForceMode2D.Impulse);
                break;
            case RigidbodyType2D.Kinematic:
                rb.velocity = direction.normalized * 3f * strength * rb.mass;
                isStarted = true;
                break;
        }
        yield return new WaitForSeconds(1f);
        yield return null;
    }
    override public IEnumerator Stop() {
        yield return null;
    }
}
