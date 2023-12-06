using System.Collections;
using UnityEngine;

public class Stoping : BaseProperty
{
    public float time = 1f;

    override public IEnumerator Complete() {
        yield return new WaitForSeconds(time);
        yield return null;
    }
    override public IEnumerator Stop() {
        yield return null;
    }
}
