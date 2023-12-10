using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
        TEST(); // УДАЛИТЬ!
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
        string[] text = new string[4]{"Привет! Я твоя перчатка Первопроходца!", "Сейчас мы познакомимся со всеми моими возможностями, ты же ведь испытатель, да?", 
        "Впрочем начнем с малого: Ты можешь программировать предметы!", "Постарайся передвинуть тот энергетический куб, чтобы открыть дверь"};
        Player.GetComponent<Movement_2D>().StartDialogue(text);
    }
}
