using UnityEngine;

public class ClickOn : BaseCondition
{
    public override event System.Action action;

    Collider2D col;
    public void Start() {
        col = GetComponent<Collider2D>();
        InputManager.Instance.onClick += ctx => OnAction(ctx);
    }

    private void OnAction(Vector2 pos) {
        if (col.bounds.Contains(pos)) {
            action?.Invoke();
        }
    }
}
