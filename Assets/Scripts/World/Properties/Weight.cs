using System.Collections;
using UnityEngine;

public class Weight : BaseProperty
{
    Rigidbody2D rb; 
    float mass = 10f;

    float firstMass = 0f;
    public void Start() {
        rb = transform.GetComponent<Rigidbody2D>();
        firstMass = rb.mass;
    }

    override public IEnumerator Complete() {
        rb.mass = mass;
        yield return new WaitForSeconds(1f);
        yield return null;
    }
    override public IEnumerator Stop() {
        rb.mass = firstMass;
        yield return null;
    }
}
