using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScript : MonoBehaviour
{
    public Rigidbody2D buttonTopRB;
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public AudioSource pressedSound;
    public AudioSource releasedSound;
    public Collider2D[] CollidersToIgnore;
    public UnityEvent onPressed;
    public UnityEvent onReleased;

    void Start() {
        Collider2D localCollider = GetComponent<Collider2D>();
        if (localCollider != null) {
            Physics2D.IgnoreCollision(localCollider, buttonTop.GetComponentInChildren<Collider2D>());
            foreach (Collider2D singleCollider in CollidersToIgnore) {
                Physics2D.IgnoreCollision(localCollider, singleCollider);
            }
        }
        
        if (transform.eulerAngles != Vector3.zero){
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        } else upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }

    void Update() {
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else buttonTopRB.AddForce(buttonTop.transform.up * force * Time.deltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);


        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold) isPressed = true;
        else isPressed = false;

        if(isPressed && prevPressedState != isPressed) Pressed();
        if(!isPressed && prevPressedState != isPressed) Released();
    }

    void Pressed(){
        prevPressedState = isPressed;
        pressedSound.pitch = 2f;
        pressedSound.Play();
        onPressed.Invoke();
    }

    void Released(){
        prevPressedState = isPressed;
        releasedSound.pitch = Random.Range(1.1f, 1.2f);
        releasedSound.Play();
        onReleased.Invoke();
    }
}