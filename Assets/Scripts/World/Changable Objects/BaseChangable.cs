using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseChangable : MonoBehaviour
{
    public bool isFinished = true;
    public GameObject menu;
    private ICondition condition;
    List<IProperty> queue = new List<IProperty>();

    // доделать здесь все, добавив удаление компонентов с обьекта
    #region constructions 
    public void SetCondition(ICondition _condition) { 
        condition = _condition;
        condition.action += OnStart;
    }

    public void ChangeEndless() => condition.isEndless = !condition.isEndless;
    public void AddToQueue(IProperty property) => queue.Add(property);
    public void RemoveFromQueue(IProperty property) => queue.Remove(property);
    public void RemoveFromQueue(int index) => queue.RemoveAt(index);
    public void ClearQueue() { 
        foreach (var p in queue) {
            foreach (var component in GetComponents<Component>()) {
                if (component != null && p.GetType().IsAssignableFrom(component.GetType())) {
                    Destroy(component);
                }
            }
        }
        queue.Clear(); 
    }
    #endregion

    public abstract void OnStart();

    public void UseUI() {
        menu.SetActive(true);
    }

    public void UnuseUI() {
        menu.SetActive(false);
    }

    public IEnumerator ExecuteSequence() {
        isFinished = false;
        foreach (IProperty prop in queue) yield return StartCoroutine(prop.Complete());
        if (!condition.isEndless) {
            foreach (IProperty prop in queue) yield return StartCoroutine(prop.Stop());
        }
        isFinished = true;
        yield return null;
    }
}
