using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerButtonScript : MonoBehaviour, IInteractable
{
    public UnityEvent action;
    public AudioSource audioSound;

    bool isToggle = false;
    int isActivated = 0;
    Animator animator;
    private void Start() {
        animator = transform.GetComponent<Animator>();
    }

    public void Activate() {
        isActivated++;
    }
    private void Update() {
        if (isActivated != 1) return; 
        audioSound.pitch = 1f;
        audioSound.Play();
        action?.Invoke();
        isToggle = true;
        animator.SetBool("IsToggled", isToggle);
    }
}
