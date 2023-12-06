using UnityEngine;
using System.Collections;

[System.Serializable]
public abstract class BaseProperty : MonoBehaviour, IProperty
{
    public abstract IEnumerator Complete();
    public abstract IEnumerator Stop();

}
