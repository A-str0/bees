using UnityEngine;

public class Touch : BaseCondition
{
    public override event System.Action action;

    public string tagg = "";

    Collider2D col;
    public void Start() {
        col = GetComponent<Collider2D>();
    }

    public void OnCollisionEnter2D(Collision2D col) {
        if (tagg == "") action?.Invoke();
        else { if (col.gameObject.tag == tagg) action?.Invoke();}
    } 
}
