using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallScript : BaseChangable
{
    override public void OnStart() {
        if (isFinished) StartCoroutine(ExecuteSequence());
    }
}
