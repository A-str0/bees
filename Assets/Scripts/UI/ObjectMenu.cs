using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ObjectMenu : MonoBehaviour
{
    BaseChangable par;
    [SerializeField] TMP_Text text;
    [SerializeField] FieldsScript inputField;

    private void Start() {
        par = transform.parent.GetComponent<BaseChangable>();
    }
    private void Update() {
        transform.eulerAngles = Vector3.zero;
    }

    public void Close() {
        GameManager.Player.GetComponent<Movement_2D>().UnuseUI();
        par.UnuseUI();
    }

    public void Clear() {
        par.ClearQueue();
        text.text = "";
    }

    public void ChangeEndless() => par.ChangeEndless();

    public void AddCondition(string cond) {
        text.text = "if (" + cond + "):\n" + text.text;
        switch (cond) {
            case "Touch":
                par.SetCondition(par.gameObject.AddComponent<Touch>());
                inputField.SetActiveField("Touch");
                break;
            case "Click":
                par.SetCondition(par.gameObject.AddComponent<ClickOn>());
                break;
            case "Near":
                par.SetCondition(par.gameObject.AddComponent<Near>());
                inputField.SetActiveField("Near");
                break;
        }
    }

    public void AddProperty(string prop) {
        text.text = text.text + " " + prop + ";\n";
        switch (prop) {
            case "Explode":
                par.AddToQueue(par.gameObject.AddComponent<Explode>());
                inputField.SetActiveField("Explode");
                break;
            case "FollowPath":
                par.AddToQueue(par.gameObject.AddComponent<FollowPath>());
                inputField.SetActiveField("FollowPath");
                break;
            case "Freeze":
                par.AddToQueue(par.gameObject.AddComponent<Freeze>());
                inputField.SetActiveField("Freeze");
                break;
            case "Impulse":
                par.AddToQueue(par.gameObject.AddComponent<Impulse>());
                inputField.SetActiveField("Impulse");
                break;
            case "Wait":
                par.AddToQueue(par.gameObject.AddComponent<Wait>());
                inputField.SetActiveField("Wait");
                break;
            case "Weight":
                par.AddToQueue(par.gameObject.AddComponent<Weight>());
                inputField.SetActiveField("Weight");
                break;
            case "ZeroGravity":
                par.AddToQueue(par.gameObject.AddComponent<ZeroGravity>());
                break;
        }
    }
}
