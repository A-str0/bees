using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToggleScript : MonoBehaviour
{
    public UnityEvent<bool> action;

    bool isToggled;

    public void OnToggleChanged(bool isTrue) {
        isToggled = isTrue;
        action?.Invoke(isToggled);
    }
}
