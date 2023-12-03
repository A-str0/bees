using System.Collections;
using UnityEngine;

public class Freeze : BaseProperty
{
    Rigidbody2D rb; 
    public float time = 1f;

    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    override public IEnumerator Complete() {
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        rb.freezeRotation = true;
        yield return new WaitForSeconds(time);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.freezeRotation = false;
        yield return new WaitForSeconds(0.2f);
        yield return null;
    }
    override public IEnumerator Stop() {
        yield return null;
    }
}
