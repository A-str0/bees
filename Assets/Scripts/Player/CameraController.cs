using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float dumping = 1.5f;
    public Vector2 offset = new Vector2(0f, 0f);
    public Transform currentObj;

    void Start()
    {
        offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
    }

    public void FindPlayer()
    {
        currentObj = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = new Vector3(currentObj.position.x + offset.x, transform.position.y, transform.position.z);
    }


    void Update()
    {
        if(currentObj)
        {
            Vector3 target;
            target = new Vector3(currentObj.position.x + offset.x, transform.position.y, transform.position.z);
            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
