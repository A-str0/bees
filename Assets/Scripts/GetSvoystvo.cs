using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class GetSvoystvo : MonoBehaviour
{
    public int countForProperty;
    public Text gg;
    public BaseChangable obj;
    public Text txt;

    public void GetFreeze()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            obj.AddToQueue(obj.gameObject.AddComponent<Freeze>());
            txt.text = txt.text + "Заморозить на " + "*циферки*" + "\r\n";
        }
    }

    public void GetImpulse()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            Impulse imp = obj.gameObject.AddComponent<Impulse>();
            imp.direction = Vector2.right; imp.strength = 10f;
            obj.AddToQueue(imp);
            txt.text = txt.text + "Отбросить c силой " + imp.strength + "\r\n";
        }
    }
    public void GetZero()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            obj.AddToQueue(obj.gameObject.AddComponent<ZeroGravity>());
            txt.text = txt.text + "Отключить гравитацию на " + "циферки" + "\r\n";
        }
    }

    public void GetExplode()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            obj.AddToQueue(obj.gameObject.AddComponent<Explode>());
            txt.text = txt.text + "взорвать " + "циферки" + "\r\n";
        }
    }

    public void GetFollowPath()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            FollowPath fp = obj.gameObject.AddComponent<FollowPath>();
            obj.AddToQueue(fp);
            txt.text = txt.text + "Отбросить c силой " + "циферки" + "\r\n";
        }
    }

    public void GetGrab()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            Grab grab = obj.gameObject.AddComponent<Grab>();
            obj.AddToQueue(grab);
            txt.text = txt.text + "Схватить " + "циферки" + "\r\n";
        }
    }

    public void GetStopping()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            Stoping stop = obj.gameObject.AddComponent<Stoping>();
            obj.AddToQueue(stop);
            txt.text = txt.text + "Остановить на " + "*циферки*" + "\r\n";
        }
    }

    public void GetWait()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            Wait wait = obj.gameObject.AddComponent<Wait>();
            obj.AddToQueue(wait);
            txt.text = txt.text + "Подождать " + "циферки" + "\r\n";
        }
    }

    public void GetWeight()
    {
        if(obj.GetComponent<ClickOn>() || obj.GetComponent<Near>() || obj.GetComponent<PlayerNear>() || obj.GetComponent<Touch>())
        {
            obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
            Weight weight = obj.gameObject.AddComponent<Weight>();
            obj.AddToQueue(weight);
            txt.text = txt.text + "Ширина " + "циферки" + "\r\n";
        }
    }


    public void GetOnClick()
    {
        txt.text = txt.text + "Если кликнуть на объект, то: " + "\r\n";
        obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
        ClickOn condom = obj.gameObject.AddComponent<ClickOn>();
        condom.isEndless = true;
        obj.SetCondition(condom);
    }

    public void GetNear()
    {
        txt.text = txt.text + "Если рядом с объектом, то: " + "\r\n";
        obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
        Near condom = obj.gameObject.AddComponent<Near>();
        condom.isEndless = true;
        obj.SetCondition(condom);
    }

    public void GetPlayerNear()
    {
        txt.text = txt.text + "Если игрок рядом с объектом, то: " + "\r\n";
        obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
        PlayerNear condom = obj.gameObject.AddComponent<PlayerNear>();
        condom.isEndless = true;
        obj.SetCondition(condom);
    }

    public void GetTouch()
    {
        txt.text = txt.text + "Если коснуться объекта, то: " + "\r\n";
        obj = FindObjectOfType<Telekenesis>().selectedObject.gameObject.GetComponent<BaseChangable>();
        Touch condom = obj.gameObject.AddComponent<Touch>();
        condom.isEndless = true;
        obj.SetCondition(condom);
    }

}
