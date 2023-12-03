using UnityEngine;

public class Touch : BaseCondition
{
    public override event System.Action action;

    Collider2D col;
    public void Start() {
        col = GetComponent<Collider2D>();
    }

    public void OnCollisionEnter2D() {
        action?.Invoke();
    } 
}
