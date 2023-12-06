using UnityEngine;
using System.Collections;

public interface IProperty 
{
    public abstract IEnumerator Complete();
    public abstract IEnumerator Stop();
}
