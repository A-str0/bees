using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Telekenesis : MonoBehaviour
{
    //[SerializeField] Camera cameraObj;
    public Transform selectedObject;
    public GameObject Window;

    void Start()
    {
        Window.SetActive(false);
    }
    void Update()
    {
        var p = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        var hit2D = Physics2D.Raycast(p, Vector2.zero); 
 
        if(Input.GetMouseButtonDown(0))
        {    if (hit2D.transform != null && hit2D.transform.CompareTag("Box"))
            {
                selectedObject = hit2D.transform;
                GetComponent<CameraController>().currentObj = selectedObject;
                Window.SetActive(true);
                //Time.timeScale = 0.4f;
            }
            else
            {
                //Time.timeScale = 1f;
                //
            }
        }     
    }

    public void Close()
    {
        //selectedObject.
        GetComponent<CameraController>().currentObj = FindObjectOfType<Movement_2D>().transform;
        selectedObject = null;
        Window.SetActive(false);
    }

}
