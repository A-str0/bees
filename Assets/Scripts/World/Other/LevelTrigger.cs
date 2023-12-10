using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public string[] dialogue;
    bool wasActivated = false;

    private void OnTriggerEnter2D(Collider2D col) {
        if (wasActivated) return;
        if (col.gameObject.TryGetComponent<Movement_2D>(out Movement_2D mov)) {
            mov.StartDialogue(dialogue);
            wasActivated = true;
        }
    }
}
