using UnityEngine;

public class PlayerNear : BaseCondition
{
    public override event System.Action action;

    public float radius = 2f;

    public void Update() {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, radius);
        for (int i = 0; i < hitColliders.Length; ++i) {
            if(hitColliders[i].tag == "Player") {
                action?.Invoke();
            }
        }
    }
}
