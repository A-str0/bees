using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetSvoystvo : MonoBehaviour
{
    public int countForProperty;
    public Text gg;

    public void GetFreeze()
    {
        FindObjectOfType<Telekenesis>().selectedObject.gameObject.AddComponent<Freeze>();
        countForProperty = int.Parse(gg.text);
        //gg.text.int.TryParse(gg.text, out countForProperty);
        //FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<Freeze>().time = (float)countForProperty;
    }

    public void GetImpulse()
    {
        FindObjectOfType<Telekenesis>().selectedObject.gameObject.AddComponent<Impulse>();
    }
    public void GetZero()
    {
        FindObjectOfType<Telekenesis>().selectedObject.gameObject.AddComponent<ZeroGravity>();
    }
}
