using UnityEngine;

public abstract class BaseCondition : MonoBehaviour, ICondition
{
    public abstract event System.Action action;
    public bool isEndless { get; set;}
}
