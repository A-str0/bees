using System.Collections;
using UnityEngine;

public class Impulse : BaseProperty
{
    Rigidbody2D rb; 
    public Vector2 direction = new(1f, 0f);
    public float strength = 2f;

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    override public IEnumerator Complete() {
        rb.AddForce(direction.normalized * 3f * strength * rb.mass, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.4f);
        yield return null;
    }
    override public IEnumerator Stop() {
        yield return null;
    }
}
