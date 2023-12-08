using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static GameObject Player { get; private set; }

    public GameObject explosion;

    private void Awake() {
        if (Instance == null) Instance = this;
        else Debug.LogWarning("GameManager is already instanced");

        if (Player == null) Player = GameObject.FindWithTag("Player");
    }

    private void Start() {
       //TEST(); // УДАЛИТЬ!
    }

    public GameObject GetNearestPath(Vector3 pos) {
        GameObject path = null; float dist = float.MaxValue;
        foreach (var obj in GameObject.FindGameObjectsWithTag("Path")) {
            if (Vector3.Distance(pos, obj.transform.position) < dist) {
                dist = Vector3.Distance(pos, obj.transform.position);
                path = obj;
            }
        }
        return path;
    }

    private void TEST() {
        BaseChangable obj =  GameObject.FindGameObjectWithTag("Box").GetComponent<BaseChangable>();
        ClickOn condom = obj.gameObject.AddComponent<ClickOn>();
        condom.isEndless = true;
        obj.SetCondition(condom);
        obj.AddToQueue(obj.gameObject.AddComponent<ZeroGravity>());
        Impulse imp = obj.gameObject.AddComponent<Impulse>();
        imp.direction = Vector2.right; imp.strength = 10f;
        obj.AddToQueue(imp);
        obj.AddToQueue(obj.gameObject.AddComponent<Explode>());
    }
}
