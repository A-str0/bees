using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlatformScript : BaseChangable
{
    Rigidbody2D rb;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        rb.freezeRotation = true;
    }

    override public void OnStart() {
        if (isFinished) StartCoroutine(ExecuteSequence());
    }
}
