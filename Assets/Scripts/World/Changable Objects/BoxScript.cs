using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoxScript : MonoBehaviour, IChangeable
{
    ICondition condition;
    List<IProperty> queue = new List<IProperty>();

    // доделать здесь все, добавив удаление компонентов с обьекта
    #region constructions 
    public void SetCondition(ICondition _condition) => condition = _condition;
    public void AddToQueue(IProperty property) => queue.Add(property);
    public void RemoveFromQueue(IProperty property) => queue.Remove(property);
    public void RemoveFromQueue(int index) => queue.RemoveAt(index);
    public void ClearQueue() => queue.Clear();
    #endregion

    private void Start() {

        //ПРИМЕР ПОСЛЕДОВАТЕЛЬНОСТИ!
        PlayerNear condom = transform.AddComponent<PlayerNear>();
        condition = condom;

        Grab grab = transform.AddComponent<Grab>(); //говно переделывай
        Impulse impulse = transform.AddComponent<Impulse>(); //говно переделывай
        Freeze freeze = transform.AddComponent<Freeze>(); //говно переделывай
        queue.Add(grab); // это тожt
        queue.Add(impulse); // это тожt
        queue.Add(freeze); // это тожt

        condition.action += OnStart;
    }

    private void OnStart() {
        if (isFinished) StartCoroutine(ExecuteSequence());
    }

    bool isFinished = true;
    private IEnumerator ExecuteSequence() {
        isFinished = false;
        foreach (IProperty prop in queue) 
            yield return StartCoroutine(prop.Complete());
        foreach (IProperty prop in queue) 
            yield return StartCoroutine(prop.Stop());
        isFinished = true;
        yield return null;
    }
}
