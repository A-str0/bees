using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BoxScript : BaseChangable
{
    override public void OnStart() {
        if (isFinished) StartCoroutine(ExecuteSequence());
    }
}
