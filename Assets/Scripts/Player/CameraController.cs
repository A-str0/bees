using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    public float zoom = 3f;
    public Vector2 offset = new Vector2(0f, 0f);
    public Transform currentObj;

    Transform defaultObj;
    Camera cam;

    void Start() {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        cam = transform.GetComponent<Camera>();
        FindPlayer();
        defaultObj = currentObj;
    }

    public void FindPlayer() {
        currentObj = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(currentObj.position.x + offset.x, transform.position.y, transform.position.z);
    }

    public void Concentrate(Transform obj) {
        currentObj = obj;
        cam.orthographicSize = 5f - zoom;
    }
    public void Unconcentrate() {
        currentObj = defaultObj;
        cam.orthographicSize = 5f;
    }


    Vector3 target;
    private void FixedUpdate() {
        if(!currentObj) return;

        target = new Vector3(currentObj.position.x, currentObj.position.y, -10) + new Vector3(offset.x, offset.y, 0);
        Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
        transform.position = currentPosition;
    }
}
