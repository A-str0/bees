using UnityEngine;
using UnityEngine.Events;

public class HoneyContainerScript : MonoBehaviour
{
    [SerializeField] float maxValue = 1f;
    [SerializeField] float cur = 0f;

    public UnityEvent onFilled;
    public UnityEvent onEmpty;

    public void Fill(float value) {
        cur = Mathf.Clamp(cur+value, 0f, maxValue);
        if (cur == maxValue) onFilled?.Invoke();
    }

    public void Empty() {
        cur = 0;
        onEmpty?.Invoke();
    }
}
